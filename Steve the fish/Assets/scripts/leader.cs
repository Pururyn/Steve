using System.Collections.Generic;
using System.Linq;
using Unity;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Leader : MonoBehaviour
{
    [SerializeField] private Boid boid;
    List<Boid> boids = new List<Boid>();

    private void Start()
    {
        boid = GetComponent<Boid>();
        var boids = FindObjectsByType<Boid>(FindObjectsSortMode.InstanceID);
        foreach (var other in boids.Where(b => b != boid))
        {
            
        }
    }


}