using UnityEngine;
using StarterAssets;
public class Weapon : MonoBehaviour
{

    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask hitLayerMask;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    StarterAssetsInputs starterAssetsInputs;

    // Update is called once per frame
    void Update()
    {
        // if(starterAssetsInputs.shoot)
        // {
        //     muzzleFlash.Play();
        //     animator.Play(shootAnimation, 0, 0f);
        //     starterAssetsInputs.ShootInput(false);
        //     Shoot();
        // }
    }

    public void Shoot(WeaponSO weaponSO)
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, hitLayerMask, QueryTriggerInteraction.Ignore))
        {
            Instantiate(weaponSO.hitVFXPrefab, hit.point, Quaternion.identity);
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * Mathf.Infinity, Color.red);
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.damage);
        }
    }
}
