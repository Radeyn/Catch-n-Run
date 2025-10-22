using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGameScript : MonoBehaviour
{
    private readonly Vector3 _startPoint = new Vector3(0f, 0.94f, 0f);
    
    
    private PlayerControl playerControl;
    [SerializeField]private GameOver gameOver;
    [SerializeField]private SpawnScript spawnScript;
    [SerializeField]private StartCountdown startCountdown;
    [SerializeField]private Score score;
    [SerializeField]private GameObject gameOverUI;
    [SerializeField]private PlayerStatus playerStatus;

    private void Start()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
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

        spawnScript.ResetSpikeGravity();
        spawnScript.ResetSpawnInterval();
        gameOver.ResetAnimation();


        score.ResetScore();
        playerStatus.ResetHealth();
        playerStatus.ResetSpeed();
        playerStatus.ResetWeight();
        if (playerControl.transform != null) playerControl.transform.position = _startPoint;

        gameOverUI.SetActive(false);
        
        
        StartCoroutine(startCountdown.StartCountdownRoutine());
        
        


    }
}
