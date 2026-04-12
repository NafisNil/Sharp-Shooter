using UnityEngine;
using StarterAssets;
public class ActiveWeapon : MonoBehaviour
{
   
    Animator animator;
    const string shootAnimation = "shoot";
    [SerializeField] private int damage = 10;
    [SerializeField] WeaponSO weaponSO;
    StarterAssetsInputs starterAssetsInputs;
    float timeSinceLastShot = 0f;

    Weapon currentWeapon;
    void Start()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        currentWeapon = GetComponentInChildren<Weapon>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if(timeSinceLastShot >= weaponSO.fireRate)
        {
            if(starterAssetsInputs.shoot)
            {
                
                animator.Play(shootAnimation, 0, 0f);
                starterAssetsInputs.ShootInput(false);
                currentWeapon.Shoot(weaponSO);
                timeSinceLastShot = 0f;
            }
           // Shoot();
        }
    }


}
