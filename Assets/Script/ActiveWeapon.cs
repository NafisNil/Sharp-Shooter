using UnityEngine;
using StarterAssets;
using Unity.Cinemachine;
public class ActiveWeapon : MonoBehaviour
{
   
    Animator animator;
    const string shootAnimation = "shoot";
    [SerializeField] private int damage = 10;
    [SerializeField] WeaponSO weaponSO;
    StarterAssetsInputs starterAssetsInputs;
    float timeSinceLastShot = 0f;
    float defaultFOV;
    [SerializeField] private CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] GameObject zoomVignette;

    Weapon currentWeapon;
    void Start()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        currentWeapon = GetComponentInChildren<Weapon>();
        animator = GetComponent<Animator>();
        if (playerFollowCamera != null)
        {
            defaultFOV = playerFollowCamera.m_Lens.FieldOfView;
        }
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

        HandleZoom();
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

    void HandleZoom()
    {
        if (!weaponSO.canZoom)
        {
            return;
        }

        if (starterAssetsInputs.zoom)
        {
            playerFollowCamera.m_Lens.FieldOfView = weaponSO.zoomAmount;
            zoomVignette.SetActive(true);
        }
        else
        {
            playerFollowCamera.m_Lens.FieldOfView = defaultFOV;
            zoomVignette.SetActive(false);
        }


    }


}
