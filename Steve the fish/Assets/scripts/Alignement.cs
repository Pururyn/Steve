using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Alignement : MonoBehaviour
{

    private Boid boid; // Reference to the Boid component
    public float radius; // Radius to consider for cohesion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boid = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        var boids = FindObjectsByType<Boid>(FindObjectsSortMode.None);// Update the reference to the Boid component
        var average = Vector3.zero;// Initialize average position
        var found = 0; // Count of nearby boids

        foreach (var boid in boids.Where(b => b != boid)){ 
            var diff = boid.transform.position - this.transform.position; // Calculate the difference vector from this boid to the other boid

            if (diff.magnitude < radius) { // Check if the other boid is within the specified radius
                average += boid.velocity; // Accumulate the position of the nearby boid
                found++; // Increment the count of nearby boids
            }
        }

        if (found > 0) 
        { 
            average = average / found; // Calculate the average position of nearby boids
            boid.velocity += Vector3.Lerp(boid.velocity , average , Time.deltaTime); // Adjust the velocity towards the average position
        }
    }
}
