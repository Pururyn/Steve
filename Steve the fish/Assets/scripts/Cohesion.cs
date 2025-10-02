using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohesion : MonoBehaviour
{
    private Boid boid;
    public BoidSettings settings;

    void Start()
    {
        boid = GetComponent<Boid>();
    }

    void Update()
    {
        //Get all boids in the scene
        var boids = FindObjectsByType<Boid>(FindObjectsSortMode.None);
        Vector3 average = Vector3.zero;
        int found = 0;

        if (boid.isLeader) return;

        //Verify if there are other boids in the cohesion radius
        foreach (var other in boids)
        {
            if (other != boid)
            {
                Vector3 distance = other.transform.position - transform.position;

                if (distance.magnitude < settings.cohesionRadius)
                {
                    average += distance;
                    found++;
                }
            }
        }

        //If there are other boids in the cohesion radius, move towards the average position
        if (found > 0)
        {
            average /= found;
            boid.velocity += Vector3.Lerp(Vector3.zero, average, average.magnitude / settings.cohesionRadius);
        }
    }
}