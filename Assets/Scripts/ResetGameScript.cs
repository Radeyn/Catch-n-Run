using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGameScript : MonoBehaviour
{
    private readonly Vector3 _startPoint = new Vector3(0f, 1.20f, 0f);
    
    
    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField]private GameOver gameOver;
    [SerializeField]private FruitCollision fruitCollision;
    [SerializeField]private EnemyCollision enemyCollision;
    [SerializeField]private SpawnScript spawnScript;
    [SerializeField]private StartCountdown startCountdown;
    [SerializeField]private Score score;
    [SerializeField]private GameObject gameOverUI;
    [SerializeField]private PlayerStatus playerStatus;


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


        score.ResetScore();
        playerStatus.ResetHealth();
        playerMovement.MoveSpeed = 25;
        playerMovement.transform.position = _startPoint;
        
        gameOverUI.SetActive(false);
        if (SceneManager.GetActiveScene() != null)
        {
            StartCoroutine(startCountdown.StartCountdownRoutine());
        }
        


    }
}
