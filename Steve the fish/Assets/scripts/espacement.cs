using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Espacement : MonoBehaviour
{

	private Boid boid; 
	public float space; //espace minimal entre les boids


	void Start()
	{
		boid = GetComponent<Boid>();
	}

    void Update()
    {
		var boids = FindObjectsByType<Boid>(FindObjectsSortMode.None);
		var average = Vector3.zero;

		foreach (var boid in boids.Where(b => b != boid))
		{
			var diff = boid.transform.position - this.transform.position; // Calculate the difference vector from this boid to the other boid

			if (diff.magnitude < space)
			{
				average += diff; 
				found++;
			}
		}

	}

}