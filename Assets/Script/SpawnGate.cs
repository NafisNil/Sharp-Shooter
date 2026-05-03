using UnityEngine;
using System.Collections;
public class SpawnGate : MonoBehaviour
{
    [SerializeField] private GameObject robotPrefab; // The prefab for the spawn effect
    [SerializeField] private float spawnDelay = 5f; // Delay before the robot appears
    [SerializeField] Transform spawnPoint; // The point where the robot will be spawned
    PlayerHealth player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        StartCoroutine(SpawnRobot());
    }

    // Update is called once per frame
    IEnumerator SpawnRobot()
    {
        while (player)
        {
            yield return new WaitForSeconds(spawnDelay);
        // Instantiate the robot at the spawn point
            Instantiate(robotPrefab, spawnPoint.position, Quaternion.identity);
        }
        
    }
}
