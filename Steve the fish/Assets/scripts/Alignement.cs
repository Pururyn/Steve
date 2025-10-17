using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alignement : MonoBehaviour
{

    private Boid boid;
    public BoidSettings settings;

    void Start()
    {
        boid = GetComponent<Boid>();
    }


    void Update()
    {
        var boids = FindObjectsByType<Boid>(FindObjectsSortMode.None);
        Vector3 average = Vector3.zero;
        int found = 0;
        if (boid.isLeader) return;

        // Check for other boids in the alignment radius
        foreach (var other in boids)
        {
            if (other != boid)
            {
                Vector3 distance = other.transform.position - transform.position;

                if (distance.magnitude < settings.alignementRadius)
                {
                    average += other.velocity;
                    found++;
                }
            }
        }

        if (found > 0)
        {
            average /= found;
            boid.velocity += Vector3.Lerp(boid.velocity, average, Time.deltaTime);
        }
    }
}