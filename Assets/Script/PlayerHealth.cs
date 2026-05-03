using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.UI;
using StarterAssets;
public class PlayerHealth : MonoBehaviour
{
        [Range(0, 100)]
     [SerializeField] private int startingHealth = 100;

    private int currentHealth;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] Transform weaponCameraTarget;
    int gameOverVirtualCameraPriority = 20;
    [SerializeField] Image[] shieldBars;
    [SerializeField] GameObject gameOverUI;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentHealth = startingHealth;
        AdjustShieldBars();
    }

    // Update is called once per frame
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        AdjustShieldBars();
        if(currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // Implement game over logic here (e.g., show game over screen, restart level, etc.)
        weaponCameraTarget.parent = null; // Detach the weapon camera target from the player
        virtualCamera.Priority = gameOverVirtualCameraPriority; // Switch to the game over camera
        gameOverUI.SetActive(true); // Show the game over UI
        StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        if(starterAssetsInputs)
        {
            starterAssetsInputs.SetCursorState(false); // Unlock the cursor for game over screen
        }
        Destroy(this.gameObject);
    }

    void AdjustShieldBars()
    {
        int healthPerBar = startingHealth / shieldBars.Length;
        for (int i = 0; i < shieldBars.Length; i++)
        {
            if (currentHealth > healthPerBar * (i + 1))
            {
                shieldBars[i].gameObject.SetActive(true); // Enable the bar if health is above the threshold
            }
            else
            {
                shieldBars[i].gameObject.SetActive(false); // Disable the bar if health is below the threshold
            }
        }
    }
}
