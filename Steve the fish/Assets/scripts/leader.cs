using UnityEngine;
using System.Linq;

public class LeaderManager : MonoBehaviour
{
    [SerializeField] private BoidSettings settings;
    [SerializeField] private Color leaderColor = Color.yellow;
    [SerializeField] private float leaderLightIntensity = 2f;
    [SerializeField] private float leaderSpeedFactor = 0.6f; 


    [Header("Boundary Sphere")]
    [SerializeField] private Vector3 sphereCenter = Vector3.zero;
    [SerializeField] private float sphereRadius = 30f;

    private Boid leader;
    private Renderer leaderRenderer;
    private Light leaderLight;
    private Vector3 targetPoint;

    void Start()
    {
        UpdateLeader();
    }

    void Update()
    {
        // Leader toggle runtime
        if (settings.useLeader && leader == null)
            UpdateLeader();

        if (!settings.useLeader && leader != null)
            RemoveLeader();

        if (leader != null)
            MoveLeader();
    }

    void UpdateLeader()
    {
        var allBoids = FindObjectsOfType<Boid>();
        foreach (var b in allBoids)
            b.isLeader = false;

        if (settings.useLeader && allBoids.Length > 0)
        {
            int index = Random.Range(0, allBoids.Length);
            leader = allBoids[index];
            leader.isLeader = true;

            // Match leader velocity to swarm average
            Vector3 avgVel = allBoids.Where(b => b != leader)
                                     .Select(b => b.velocity)
                                     .Aggregate(Vector3.zero, (acc, v) => acc + v) / (allBoids.Length - 1);
            leader.velocity = avgVel;

            // Highlight leader
            leaderRenderer = leader.GetComponent<Renderer>();
            if (leaderRenderer != null)
                leaderRenderer.material.color = leaderColor;

            leaderLight = leader.gameObject.AddComponent<Light>();
            leaderLight.color = leaderColor;
            leaderLight.intensity = leaderLightIntensity;
            leaderLight.range = 5f;

            PickNewTarget();
        }
    }

    void RemoveLeader()
    {
        if (leader != null)
        {
            leader.isLeader = false;

            if (leaderRenderer != null)
                leaderRenderer.material.color = Color.white;

            if (leaderLight != null)
                Destroy(leaderLight);

            leader = null;
            leaderRenderer = null;
            leaderLight = null;
        }
    }

    void PickNewTarget()
    {
        // Nouveau point aléatoire dans la sphère
        Vector3 randomPoint = Random.insideUnitSphere * sphereRadius + sphereCenter;
        randomPoint.y = Mathf.Clamp(randomPoint.y, sphereCenter.y - sphereRadius, sphereCenter.y + sphereRadius);
        targetPoint = randomPoint;
    }

    void MoveLeader()
    {
        Vector3 dir = (targetPoint - leader.transform.position).normalized;

        // Small curvature for natural motion
        Vector3 randomOffset = Random.onUnitSphere * 0.05f;
        randomOffset.y *= 0.3f;
        dir = (dir + randomOffset).normalized;

        leader.velocity = Vector3.Lerp(leader.velocity, dir * settings.maxVelocity * leaderSpeedFactor, Time.deltaTime);
        leader.transform.position += leader.velocity * Time.deltaTime;
        leader.transform.rotation = Quaternion.LookRotation(leader.velocity);

        // Pick new target if close
        if (Vector3.Distance(leader.transform.position, targetPoint) < 1.5f)
            PickNewTarget();
    }
}
