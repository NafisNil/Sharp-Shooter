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
                if (!weaponSO.isAutomatic)
                {
                    starterAssetsInputs.ShootInput(false);
                }
                currentWeapon.Shoot(weaponSO);
                timeSinceLastShot = 0f;
            }
           // Shoot();
        }
    }

    public void SetWeaponSO(WeaponSO newWeaponSO)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }
        Weapon newWeapon = Instantiate(newWeaponSO.weaponPrefab, transform).GetComponent<Weapon>();
        if (newWeapon)
        {
            currentWeapon = newWeapon;
            weaponSO = newWeaponSO;
            damage = weaponSO.damage;
        }
    }


}
