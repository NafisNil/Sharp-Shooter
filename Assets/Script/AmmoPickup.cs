using UnityEngine;

public class AmmoPickup : Pickup
{
    [SerializeField] int ammoAmount = 40;
    protected override void PickupEffect(ActiveWeapon activeWeapon)
    {
        activeWeapon.AdjustAmmo(ammoAmount);
    } 
}
