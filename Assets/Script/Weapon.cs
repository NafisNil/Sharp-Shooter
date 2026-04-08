using UnityEngine;
using StarterAssets;
public class Weapon : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] ParticleSystem muzzleFlash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    StarterAssetsInputs starterAssetsInputs;
    void Start()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if(starterAssetsInputs.shoot)
        {
            muzzleFlash.Play();
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * Mathf.Infinity, Color.red);
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damage);
            starterAssetsInputs.ShootInput(false);
        }
    }
}
