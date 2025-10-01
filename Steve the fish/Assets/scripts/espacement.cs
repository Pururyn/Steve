using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Espacement : MonoBehaviour
{

	private Boid boid; 
	public float radius;
	public float espace;
	public float separationStrength;


    void Start()
	{
		boid = GetComponent<Boid>();
	}

    void Update()
    {
		var boids = FindObjectsByType<Boid>(FindObjectsSortMode.None);
		var average = Vector3.zero;
		var found = 0;

        foreach (var boid in boids.Where(b => b != boid))
		{
			var diff = this.transform.position - boid.transform.position; // Calculate the difference vector from this boid to the other boid

			if (diff.magnitude < radius && diff.magnitude > 0)
			{
				Vector3 repulse = diff.normalized / Mathf.Max(diff.magnitude, 0.01f);

				if (diff.magnitude < espace)
				{
					average += repulse;
					found++;
				}
			}
		}
		if (found > 0)
		{
            average = average / found;
            boid.velocity += average * separationStrength;

        }

	}

}