using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Rigidbody rb;
    [SerializeField] int damage;
    [SerializeField] GameObject hitVFXPrefab;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    public void Init(int damage)
    {
        this.damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();
        if(playerHealth)
        {
            playerHealth.TakeDamage(damage);
            
            Destroy(gameObject);
        }
        Instantiate(hitVFXPrefab, transform.position, Quaternion.identity);
    }
}
