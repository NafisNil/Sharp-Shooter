using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    const string playerTag = "Player";
    [SerializeField] float rotationSpeed = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(playerTag))
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            PickupEffect(activeWeapon);
            Destroy(gameObject);
        }
    }

    protected abstract void PickupEffect(ActiveWeapon activeWeapon);
}
