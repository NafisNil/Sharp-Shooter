using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemyCountText;
    [SerializeField] GameObject youWinUI;
    int enemyCount;
    const string ENEMY_LEFT_TEXT = "Enemies Left: ";

    public void EnemyDefeated(int amount)
    {
        enemyCount += amount;
        enemyCountText.text = ENEMY_LEFT_TEXT + enemyCount;
      //  UpdateEnemyCountText();
        if(enemyCount <= 0) // Assuming there are 5 enemies to defeat
        {
            youWinUI.SetActive(true); // Show the "You Win" UI
        }
    }
    public void RestartGame()
    {
        // Implement game restart logic here (e.g., reload the current scene, reset player stats, etc.)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        // Implement game quit logic here (e.g., Application.Quit() for standalone builds)
        Application.Quit();
    }
}
