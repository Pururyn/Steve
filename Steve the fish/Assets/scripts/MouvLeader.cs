using UnityEngine;
using System.Linq;

public class FollowLeader : MonoBehaviour
{
    private Boid boid;
    public BoidSettings settings;


    void Start()
    {
        boid = GetComponent<Boid>();
    }

    void Update()
    {
        if (boid.isLeader || !settings.useLeader) return;

        Boid leader = FindObjectsByType<Boid>(FindObjectsSortMode.None).FirstOrDefault(b => b.isLeader);
        if (leader == null) return;

        Vector3 behind = leader.transform.position - leader.velocity.normalized * settings.leaderFollowDistance;

        // Petit “fan” autour du leader
        float angle = Random.Range(-15f, 15f); // degrés
        Vector3 offset = Quaternion.Euler(0, angle, 0) * Vector3.right * Random.Range(0f, 2f);
        behind += offset;

        Vector3 desired = (behind - transform.position).normalized * settings.maxVelocity;
        Vector3 steer = desired - boid.velocity;

        // Limit steering
        float maxSteer = settings.maxVelocity * 0.5f;
        if (steer.magnitude > maxSteer)
            steer = steer.normalized * maxSteer;

        // Scale by distance
        float factor = Mathf.Clamp01(Vector3.Distance(transform.position, behind) / settings.leaderFollowDistance);
        boid.velocity += steer * settings.leaderFollowStrength * factor * Time.deltaTime;
    }
}
