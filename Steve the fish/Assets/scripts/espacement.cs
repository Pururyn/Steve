using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
		var average = Vector3.zero;
		var found = 0;
        if (boid.isLeader) return;
        foreach (var other in boids.Where(b => b != boid))
		{
			var diff = transform.position - other.transform.position; // Calculate the difference vector from this boid to the other boid

			if (diff.magnitude < settings.separationRadius && diff.magnitude > 0)
			{
				Vector3 repulse = diff.normalized / Mathf.Max(diff.magnitude, 0.01f);

				if (diff.magnitude < settings.espace)
				{
					average += repulse;
					found++;
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