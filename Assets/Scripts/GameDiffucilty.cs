using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    public Player player;
    private Rigidbody2D rb;
    public SpawnScript spawnScript;
    public EnemyCollision enemyCollision;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        spawnScript = FindAnyObjectByType<SpawnScript>();
        enemyCollision = FindAnyObjectByType<EnemyCollision>();
    }

    private void Update()
    {
        float score = player.score;
       

        switch (score) 
        {
            case 5:

                UpdatePlayer(22.5f, 8.25f);
                UpdateObjectSpawn(1.2f);
                //UpdateSpikeMass
                break;

            case 10:
                UpdatePlayer(20f, 8.50f);
                UpdateObjectSpawn(1f);
                break;

            case 15:
                UpdatePlayer(17.5f, 8.75f);
                UpdateObjectSpawn(0.9f);
                break;

            case 20:
                UpdatePlayer(15f, 9f);
                UpdateObjectSpawn(0.8f);

                break;

            case 25:
                UpdatePlayer(12.5f, 9.25f);
                UpdateObjectSpawn(0.7f);

                break;

            case 30:
                UpdatePlayer(10f, 9.50f);
                UpdateObjectSpawn(0.6f);

                break;

            case 35:
                UpdatePlayer(9.5f, 9.75f);
                UpdateObjectSpawn(0.5f);

                break;

            case 40:
                UpdatePlayer(9f, 10f);
                UpdateObjectSpawn(0.4f);

                break;

        }

    }

    private void UpdatePlayer(float speed, float scaleX)
    {
        player.moveSpeed = speed;
        player.transform.localScale = new Vector3(scaleX, 8, 8);
    }

    private void UpdateObjectSpawn(float maxSpawnInterval)
    {

        spawnScript.maxSpawnInterval = maxSpawnInterval;


    }

    private void UpdateSpikeMass(Rigidbody2D mass)
    {
        enemyCollision.rb.mass =  rb.mass;

    }





}
