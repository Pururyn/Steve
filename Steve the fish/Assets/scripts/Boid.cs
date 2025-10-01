using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 velocity;
    public BoidSettings settings;
    public bool isLeader = false;


    private void Start()
    {
        velocity = Random.onUnitSphere * settings.maxVelocity * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (velocity.magnitude > settings.maxVelocity) {
            velocity = velocity.normalized * settings.maxVelocity; // Limit the maximum speed of the boid
        }

        this.transform.position += velocity * Time.deltaTime; // Move the boid based on its velocity
        this.transform.rotation = Quaternion.LookRotation(velocity); // Rotate the boid to face its direction of movement
    }
}
