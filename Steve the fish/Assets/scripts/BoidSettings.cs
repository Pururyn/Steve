using UnityEngine;

[CreateAssetMenu(fileName = "BoidSettings", menuName = "Boid/Settings")]
public class BoidSettings : ScriptableObject
{
    public float alignementRadius = 30;
    public float cohesionRadius = 20;
    public float separationRadius = 30;
    public float espace = 30;
    public float separationStrength = 10;
    public float maxVelocity = 10;
}