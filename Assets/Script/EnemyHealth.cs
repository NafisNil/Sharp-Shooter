using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;
    [SerializeField] GameObject robotExplosionVFXPrefab;
    private int currentHealth;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log($"Enemy took {damageAmount} damage, current health: {currentHealth}");
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Handle enemy death here (e.g., play animation, destroy object)
        Instantiate(robotExplosionVFXPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}
