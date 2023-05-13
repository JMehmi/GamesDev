using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMoving : MonoBehaviour
{
    public Transform player;
    public float patrolRadius = 10f;
    public Transform[] waypoints;
    NavMeshAgent nav;
    RaycastHit hit;

    private EnemyState currentState = EnemyState.Patrol;

    public enum EnemyState
    {
        Idle,
        Patrol,
        Chase
    }

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrol:
                PatrolBehavior();
                break;
            case EnemyState.Chase:
                ChaseBehavior();
                break;
            default:
                break;
        }
    }

    private void PatrolBehavior()
    {
        if (!nav.pathPending && nav.remainingDistance < 0.5f)
        {
            // Choose a random waypoint within the NavMesh area
            Vector3 randomPosition = Random.insideUnitSphere * patrolRadius + transform.position;
            NavMesh.SamplePosition(randomPosition, out NavMeshHit hitted, patrolRadius, NavMesh.AllAreas);
            nav.SetDestination(hitted.position);
        }

        // Check for the player
        Vector3 rayDirection = player.transform.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("boat"))
            {
                //Has seen the player so change the state
                currentState = EnemyState.Chase;
            }
        }
    }

    private void ChaseBehavior()
    {
        // Perform chase behavior, such as moving towards the player
        Vector3 rayDirection = player.transform.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out RaycastHit hit))
        {
            if (hit.collider.gameObject == player.gameObject)
            {
                // Player is in sight of the enemy, move towards them
                nav.SetDestination(player.transform.position);
                return; // Exit early to avoid choosing a new waypoint
            }
        }

        // Player is not in sight, continue patrolling
        currentState = EnemyState.Patrol;
    }
}