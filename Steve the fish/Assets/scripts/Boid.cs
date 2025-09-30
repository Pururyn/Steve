using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 velocity;
    public float maxvelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (velocity.magnitude > maxvelocity) {
            velocity = velocity.normalized * maxvelocity; // Limit the maximum speed of the boid
        }

        this.transform.position += velocity * Time.deltaTime; // Move the boid based on its velocity
        this.transform.rotation = Quaternion.LookRotation(velocity); // Rotate the boid to face its direction of movement
    }
}
