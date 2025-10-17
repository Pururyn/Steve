using UnityEngine;

public class BoundaryForce : MonoBehaviour
{
    public Vector3 sphereCenter = Vector3.zero; // Centre de la sphère
    public float sphereRadius = 30f;            // Rayon de la sphère
    public float pushStrength = 10f;            // Force qui pousse vers l’intérieur

    private Boid boid;

    void Start()
    {
        boid = GetComponent<Boid>();
    }

    void Update()
    {
        Vector3 toCenter = sphereCenter - transform.position;
        float dist = toCenter.magnitude;

        // Si le boid est proche ou au-delà de la limite
        if (dist > sphereRadius * 0.9f) 
        {
            Vector3 pushDir = toCenter.normalized;

            boid.velocity += pushDir * pushStrength * Time.deltaTime;

            if (boid.velocity.magnitude > boid.settings.maxVelocity)
            {
                boid.velocity = boid.velocity.normalized * boid.settings.maxVelocity;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0.5f, 1f, 0.2f);
        Gizmos.DrawSphere(sphereCenter, sphereRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(sphereCenter, sphereRadius);
    }
}
