using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Alignement : MonoBehaviour
{

    private Boid boid; 
    public float radius; 

    
    void Start()
    {
        boid = GetComponent<Boid>();
    }

    
    void Update()
    {
        var boids = FindObjectsByType<Boid>(FindObjectsSortMode.None);
        var average = Vector3.zero;
        var found = 0;

        foreach (var boid in boids.Where(b => b != boid)){ 
            var diff = boid.transform.position - this.transform.position; // Calculate the difference vector from this boid to the other boid

            if (diff.magnitude < radius) { 
                average += boid.velocity; 
                found++; 
            }
        }

        if (found > 0) 
        { 
            average = average / found; // Calculate the average position of nearby boids
            boid.velocity += Vector3.Lerp(boid.velocity , average , Time.deltaTime); // Adjust the velocity towards the average position
        }
    }
}
