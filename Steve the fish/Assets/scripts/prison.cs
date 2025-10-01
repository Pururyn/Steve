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
        if (dist > sphereRadius * 0.9f) // commence avant de sortir
        {
            Vector3 pushDir = toCenter.normalized;

            // Ajoute une force qui ramène vers le centre
            boid.velocity += pushDir * pushStrength * Time.deltaTime;

            // Clamp la vitesse
            if (boid.velocity.magnitude > boid.maxvelocity)
            {
                boid.velocity = boid.velocity.normalized * boid.maxvelocity;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Affiche la sphère de confinement quand l’objet est sélectionné
        Gizmos.color = new Color(0, 0.5f, 1f, 0.2f);
        Gizmos.DrawSphere(sphereCenter, sphereRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(sphereCenter, sphereRadius);
    }
}
