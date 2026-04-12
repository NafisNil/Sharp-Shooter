using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public int damage = 1;
    public float fireRate = .5f;
    public GameObject hitVFXPrefab;
}
