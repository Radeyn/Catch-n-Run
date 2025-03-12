using System.Collections.Generic;
using UnityEngine;

public class ResetGameScript : MonoBehaviour
{

    public Player player;
    public GameObject gameOverUI;

    public HeartAnimator heartAnimator;
    public FruitCollision fruitCollision;
    public EnemyCollision enemyCollision;
    public SpawnScript spawnScript;
    public StartCountdown startCountdown;
    
    private void Start()
    {
        spawnScript = FindAnyObjectByType<SpawnScript>();
        startCountdown = FindAnyObjectByType<StartCountdown>();
    }

    private void Update()
    {
        
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

        heartAnimator.StopAllCoroutines();
        spawnScript.StopAllCoroutines();

        heartAnimator.ResetAnimation();
      
        player.score = 0;
        player.playerHealth = 4;
        player.moveSpeed = 25;
        player.transform.position = new Vector3(0, 1.20f, 0f);
        player.transform.localScale = new Vector3(8, 8, 8);
        
        gameOverUI.SetActive(false);
        
        StartCoroutine(startCountdown.StartCountdownRoutine());
        Time.timeScale = 1.0f;


    }
}
