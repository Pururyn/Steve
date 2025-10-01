using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Alignement : MonoBehaviour
{

    private Boid boid; 
<<<<<<< HEAD
    public float radius;
    public float AlignementStrenght;
=======
    public BoidSettings settings;
>>>>>>> 7349b393617fa70882e9df7bf9afddcb8abc6cad

    void Start()
    {
        boid = GetComponent<Boid>();
    }

    
    void Update()
    {
        var boids = FindObjectsByType<Boid>(FindObjectsSortMode.None);
        var average = Vector3.zero;
        var found = 0;

        foreach (var other in boids.Where(b => b != boid)){ 
            var diff = other.transform.position - this.transform.position; // Calculate the difference vector from this boid to the other boid

            if (diff.magnitude < settings.alignementRadius) { 
                average += boid.velocity; 
                found++; 
            }
        }

        if (found > 0) 
        { 
            average = average / found; // Calculate the average position of nearby boids
            boid.velocity += Vector3.Lerp(boid.velocity , average, Time.deltaTime) * AlignementStrenght; // Adjust the velocity towards the average position
        }
    }
}
