using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hide : MonoBehaviour
{
    private bool hasCollided = false;
    public float patrolRadius = 10f;
    public Transform[] waypoints;
    NavMeshAgent nav;
    RaycastHit hit;


    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        Patrol();
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "boat" && !hasCollided)
        {

            this.gameObject.SetActive(false);
            hasCollided = true;
            ScoreManager.instance.ChangeScore(10);

        }
    }
    private void Patrol()
    {
        if (!nav.pathPending && nav.remainingDistance < 0.5f)
        {
            // Choose a random waypoint within the NavMesh area
            Vector3 randomPosition = Random.insideUnitSphere * patrolRadius + transform.position;
            NavMesh.SamplePosition(randomPosition, out NavMeshHit hitted, patrolRadius, NavMesh.AllAreas);
            nav.SetDestination(hitted.position);
        }

    }
}
