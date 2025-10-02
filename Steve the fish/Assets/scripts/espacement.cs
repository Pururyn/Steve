using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espacement : MonoBehaviour
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
        var found = 0;
        if (boid.isLeader) return;

        foreach (var other in boids)
        {
            if (other != boid)
            {
                Vector3 distance = transform.position - other.transform.position; // Calculate the distanceerence vector from this boid to the other boid

                if (distance.magnitude < settings.separationRadius && distance.magnitude > 0)
                {
                    Vector3 repulse = distance.normalized / Mathf.Max(distance.magnitude, 0.01f);

                    if (distance.magnitude < settings.espace)
                    {
                        average += repulse;
                        found++;
                    }
                }
            }
        }

        if (found > 0)
        {
            average /= found;
            boid.velocity += average * settings.separationStrength;
        }
    }
}