using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 5f;
    private bool goingRight = false;

    void Update()
    {
        if (goingRight == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed); // Move right
            if (transform.position.x > 4.5) // Too far right
            {
                goingRight = false; // Switch direction
            }
        }
        else
        {
            transform.Translate(-Vector3.right * Time.deltaTime * speed); // Move left
            if (transform.position.x < -4.5) // Too far left
            {
                goingRight = true; // Switch direction
            }
        }
    }
}
