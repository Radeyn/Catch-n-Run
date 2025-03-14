using UnityEngine;

public class GameDiffucilty : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rb;
    private SpawnScript spawnScript;
    private EnemyCollision enemyCollision;
    private Vector2 moveInput;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        spawnScript = FindAnyObjectByType<SpawnScript>();
        enemyCollision = FindAnyObjectByType<EnemyCollision>();
    }

    private void Update()
    {
        int score = player.score;



        switch (score)
        {
            case int s when s >= 0 && s < 5:

                UpdatePlayer(25f, 8f);
                UpdateObjectSpawn(1.5f);
                spawnScript.UpdateSpikeGravity(1f);
                
                break;

            case int s when s > 5 && s < 10:

                UpdatePlayer(22.5f, 8.50f);
                UpdateObjectSpawn(1.2f);
                spawnScript.UpdateSpikeGravity(2f);
                break;

            case int s when s > 10 && s < 15:
                UpdatePlayer(20f, 9f);
                UpdateObjectSpawn(1f);
                spawnScript.UpdateSpikeGravity(3f);

                break;

            case int s when s > 15 && s < 20:
                UpdatePlayer(18.5f, 9.50f);
                UpdateObjectSpawn(0.7f);
                spawnScript.UpdateSpikeGravity(4f);
                break;

            case int s when s > 25 && s < 30:
                UpdatePlayer(16f, 10f);
                UpdateObjectSpawn(0.6f);
                spawnScript.UpdateSpikeGravity(5f);

                break;

            case int s when s > 35 && s < 40:
                UpdatePlayer(14.5f, 10.5f);
                UpdateObjectSpawn(0.5f);
                spawnScript.UpdateSpikeGravity(6f);

                break;

            case int s when s > 40 && s < 45:
                UpdatePlayer(13f, 11f);
                UpdateObjectSpawn(0.4f);
                spawnScript.UpdateSpikeGravity(7f);

                break;

            case int s when s > 45 && s < 50:
                UpdatePlayer(11.5f, 11.5f);
                UpdateObjectSpawn(0.3f);
                spawnScript.UpdateSpikeGravity(8f);

                break;

            case int s when s > 50 && s < 55:
                UpdatePlayer(10f, 12f);
                UpdateObjectSpawn(0.2f);
                spawnScript.UpdateSpikeGravity(9f);

                break;
            case int s when s > 55 && s <= 60:
                UpdatePlayer(9f, 12f);
                UpdateObjectSpawn(0.1f);
                spawnScript.UpdateSpikeGravity(10f);

                break;
            
                case >=60:
                UpdatePlayer(9f, 12f);
                UpdateObjectSpawn(0.1f);
                spawnScript.UpdateSpikeGravity(10f);

                break;

        }

    }

    private void UpdatePlayer(float speed, float scaleX)
    {
        player.moveInput = moveInput;

        if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-scaleX, 8f, 8f);
        }
        else if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(scaleX, 8f, 8f);
        }

        player.moveSpeed = speed;
        
    }

    private void UpdateObjectSpawn(float maxSpawnInterval)
    {

        spawnScript.maxSpawnInterval = maxSpawnInterval;


    }

 

}
