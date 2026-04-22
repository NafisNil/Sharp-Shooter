using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField] WeaponSO weaponSO; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void PickupEffect(ActiveWeapon activeWeapon)
    {
        activeWeapon.SetWeaponSO(weaponSO);
    }
}
