using UnityEngine;
using System.Linq;

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
        var boids = FindObjectsByType<Boid>(FindObjectsSortMode.None);
        Vector3 average = Vector3.zero;
        int found = 0;
        if (boid.isLeader) return;
        foreach (var other in boids.Where(b => b != boid))
        {
            Vector3 diff = other.transform.position - transform.position;
            if (diff.magnitude < settings.cohesionRadius)
            {
                average += diff;
                found++;
            }
        }

        if (found > 0)
        {
            average /= found;
            boid.velocity += Vector3.Lerp(Vector3.zero, average, average.magnitude / settings.cohesionRadius);
        }
    }
}
