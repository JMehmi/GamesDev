using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{

    public float speed = 5f;
    public float rotation;

    private void Start()
    {
        
    }

    private void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        //transform.Translate(ver, 0, hor);

        Vector3 movementDirection = new Vector3(ver, 0, hor);
        movementDirection.Normalize();

        transform.Translate(movementDirection* speed* Time.deltaTime,Space.World);

        //Does not work the way it should
       /* if (movementDirection != Vector3.zero)
        {
            transform.forward = movementDirection;
            Quaternion toRotate = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotation * Time.deltaTime);

        }*/

    }
}

