using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private int explosionDamage = 30;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Explode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            PlayerHealth playerHealth = nearbyObject.GetComponent<PlayerHealth>();
            if(!playerHealth)
            {
                continue; // Skip if the object doesn't have PlayerHealth
            }
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(explosionDamage); // Apply damage to the player
            }

            break; // Assuming we only want to damage the player once, we can break after the first hit
        }
    }
}
