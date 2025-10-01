using UnityEngine;

[CreateAssetMenu(menuName = "Boids/Settings")]
public class BoidSettings : ScriptableObject
{
    public float maxVelocity = 5f;

    public float cohesionRadius = 10f;
    public float separationRadius = 5f;
    public float alignementRadius = 8f;

    public float separationStrength = 1f;
    public float cohesionStrength = 1f;
    public bool useLeader = false;
    public float espace = 2f;
    public float leaderFollowDistance = 5f;
    public float leaderFollowStrength = 2f;
}
