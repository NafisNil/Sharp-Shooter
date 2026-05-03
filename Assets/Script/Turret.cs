using UnityEngine;
using System.Collections;
public class Turret : MonoBehaviour
{
    [SerializeField] Transform turretHead;
    [SerializeField] Transform playerTargetPoint;
    [SerializeField] Transform projectileSpawnPoint;
    PlayerHealth playerHealth;
    [SerializeField] float fireRate = 2f;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] int damage = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(FireProjectile());
    }

    // Update is called once per frame
    void Update()
    {
        turretHead.LookAt(playerTargetPoint);
    }

    IEnumerator FireProjectile()
    {
        while(playerHealth)
        {
            yield return new WaitForSeconds(fireRate);
            Projectile projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity).GetComponent<Projectile>();
            projectile.transform.LookAt(playerTargetPoint);
            projectile.Init(damage);
        }
    }
}
