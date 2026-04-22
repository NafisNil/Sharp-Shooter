using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject weaponPrefab;
    public int damage = 1;
    public float fireRate = .5f;
    public GameObject hitVFXPrefab;
    public bool isAutomatic = false;
    public bool canZoom = false;
    public float zoomAmount = 10f;
    public float zoomRotationSpeed = .4f;
    public int maxAmmo = 30;
}
