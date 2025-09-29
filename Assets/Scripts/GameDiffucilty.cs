using UnityEngine;

public class GameDiffucilty : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rb;
    private SpawnScript spawnScript;
    private EnemyCollision enemyCollision;
    private Vector2 moveInput;
    private Score _score;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        spawnScript = FindAnyObjectByType<SpawnScript>();
        enemyCollision = FindAnyObjectByType<EnemyCollision>();
        _score = FindAnyObjectByType<Score>();
    }

    private void Update()
    {
        int score = _score.currentScore;




        if (score >= 0 && score < 5)
        {
            UpdatePlayer(25f, 8f);
            UpdateObjectSpawn(1.5f);
            spawnScript.UpdateSpikeGravity(1f);
        }

        else if (score >= 5 && score < 10)
        {
            UpdatePlayer(22.5f, 8.50f);
            UpdateObjectSpawn(1.2f);
            spawnScript.UpdateSpikeGravity(2f);
        }

        else if (score >= 10 && score < 15)
        {
            UpdatePlayer(20f, 9f);
            UpdateObjectSpawn(1f);
            spawnScript.UpdateSpikeGravity(3f);
        }

        else if (score >= 15 && score < 20)
        {
            UpdatePlayer(18.5f, 9.50f);
            UpdateObjectSpawn(0.7f);
            spawnScript.UpdateSpikeGravity(4f);
        }

        else if (score >= 20 && score < 25)
        {
            UpdatePlayer(16f, 10f);
            UpdateObjectSpawn(0.6f);
            spawnScript.UpdateSpikeGravity(5f);
        }

        else if (score >= 25 && score < 30)
        {
            UpdatePlayer(14.5f, 10.5f);
            UpdateObjectSpawn(0.5f);
            spawnScript.UpdateSpikeGravity(6f);
        }

        else if (score >= 30 && score < 35)
        {
            UpdatePlayer(13f, 11f);
            UpdateObjectSpawn(0.4f);
            spawnScript.UpdateSpikeGravity(7f);
        }

        else if (score >= 35 && score < 40)
        {
            UpdatePlayer(11.5f, 11.5f);
            UpdateObjectSpawn(0.3f);
            spawnScript.UpdateSpikeGravity(8f);
        }

        else if (score >= 40 && score < 45)
        {
            UpdatePlayer(10f, 12f);
            UpdateObjectSpawn(0.2f);
            spawnScript.UpdateSpikeGravity(9f);
        }

        else if (score >= 45 && score < 50)
        {
            UpdatePlayer(9f, 12f);
            UpdateObjectSpawn(0.1f);
            spawnScript.UpdateSpikeGravity(10f);
        }

        else
        {
            UpdatePlayer(9f, 12f);
            UpdateObjectSpawn(0.1f);
            spawnScript.UpdateSpikeGravity(10f);
        }

    

    }

    private void UpdatePlayer(float speed, float scaleX)

    {
        player.MoveSpeed = speed;
        player.scaleX = scaleX;
        player.moveInput = moveInput;


        if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-scaleX, 8f, 8f);
        }

        else if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(scaleX, 8f, 8f);
        }

        
        
    }

    private void UpdateObjectSpawn(float maxSpawnInterval)
    {

        spawnScript.maxSpawnInterval = maxSpawnInterval;


    }

 

}
