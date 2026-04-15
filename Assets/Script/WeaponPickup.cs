using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO; 
    const string playerTag = "Player";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(playerTag))
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            if(activeWeapon != null)
            {
                activeWeapon.SetWeaponSO(weaponSO);
                Destroy(gameObject);
            }
        }
    }
}
