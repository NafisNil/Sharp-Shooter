using UnityEngine;
using StarterAssets;
using Unity.Cinemachine;
using TMPro;
public class ActiveWeapon : MonoBehaviour
{
   
    Animator animator;
    const string shootAnimation = "shoot";
    [SerializeField] private int damage = 10;
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] WeaponSO startingWeaponSO;
    [SerializeField] TMP_Text ammoText;
    StarterAssetsInputs starterAssetsInputs;
    float timeSinceLastShot = 0f;
    float defaultFOV;
    float defaultRotationSpeed;
    [SerializeField] private CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] GameObject zoomVignette;
    int currentAmmo;

    FirstPersonController firstPersonController;

    Weapon currentWeapon;
    void Start()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        SetWeaponSO(startingWeaponSO);
        AdjustAmmo(weaponSO.maxAmmo);
        currentWeapon = GetComponentInChildren<Weapon>();
        animator = GetComponent<Animator>();
        defaultRotationSpeed = firstPersonController.RotationSpeed;
        if (playerFollowCamera != null)
        {
            defaultFOV = playerFollowCamera.m_Lens.FieldOfView;
        }
    }
    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if(timeSinceLastShot >= weaponSO.fireRate && currentAmmo > 0)
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
                AdjustAmmo(-1);
            }
           // Shoot();
        }

        HandleZoom();
    }


    public void AdjustAmmo(int amount)
    {
        currentAmmo += amount;
        if (currentAmmo > weaponSO.maxAmmo)
        {
            currentAmmo = weaponSO.maxAmmo;
        }
        ammoText.text = currentAmmo.ToString("D2");
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
            AdjustAmmo(weaponSO.maxAmmo);
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
            firstPersonController.ChangeRotationSpeed(weaponSO.zoomRotationSpeed);
        }
        else
        {
            playerFollowCamera.m_Lens.FieldOfView = defaultFOV;
            zoomVignette.SetActive(false);
            firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);
        }


    }


}
