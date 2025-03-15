using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGameScript : MonoBehaviour
{

    private Player player;
    private GameOver gameOver;
    private FruitCollision fruitCollision;
    private EnemyCollision enemyCollision;
    private SpawnScript spawnScript;
    private  StartCountdown startCountdown;

    public GameObject gameOverUI;

    private void Start()
    {
        spawnScript = FindAnyObjectByType<SpawnScript>();
        startCountdown = FindAnyObjectByType<StartCountdown>();
        gameOver = FindAnyObjectByType<GameOver>();
        player = FindAnyObjectByType<Player>();
    }

    public void ResetGame()
    {


        foreach (GameObject enemy in spawnScript.spawnedEnemies)
        {
            if (enemy != null)
                Destroy(enemy);
        }
        spawnScript.spawnedEnemies.Clear();

        foreach (GameObject fruit in spawnScript.spawnedFruits)
        {
            if (fruit != null)
                Destroy(fruit);
        }   
        spawnScript.spawnedFruits.Clear();


        spawnScript.StopAllCoroutines();
        gameOver.StopAllCoroutines();

        
        spawnScript.maxSpawnInterval = 1.5f;
        gameOver.ResetAnimation();


        player.score = 0;
        player.playerHealth = 4;
        player.moveSpeed = 25;
        player.transform.position = new Vector3(0, 1.20f, 0f);
        
        gameOverUI.SetActive(false);
        if (SceneManager.GetActiveScene() != null)
        {
            StartCoroutine(startCountdown.StartCountdownRoutine());
        }
        


    }
}
