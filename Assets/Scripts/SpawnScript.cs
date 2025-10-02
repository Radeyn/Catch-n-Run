using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField]private Score score;
    [SerializeField]private PlayerStatus playerStatus;
    [SerializeField]private GameObject spawnPosition;
    
    private Rigidbody2D rb;
    private int startTimer = 3;
    public float gravityScale;

    public Transform[] spawnPointsFruit; 
    public Transform[] spawnPointsEnemy; 
    public GameObject[] fruitPrefabs;
    public GameObject[] enemyPrefabs;

    public float minSpawnInterval = 0.1f; 
    public float maxSpawnInterval = 1.5f; 

    public List<GameObject> spawnedEnemies = new List<GameObject>();
    public List<GameObject> spawnedFruits = new List<GameObject>();

    
   
    private void Start()
    {  
        rb = GetComponent<Rigidbody2D>();
        
    }

    public IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(startTimer);
        StartCoroutine(SpawnObjects());

    }


    // ReSharper disable Unity.PerformanceAnalysis
    public IEnumerator SpawnObjects()
    {
        
        while (true)
        {

            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            yield return new WaitForSeconds(spawnInterval);

            Vector2 spawnPositionEnemy = new Vector2(
                Random.Range((float)-12, (float)20),
                Random.Range((float)16, (float)17)

            );
            
            Vector2 spawnPositionFruit = new Vector2(
                Random.Range((float)-12, (float)20),
                Random.Range((float)16, (float)17)

            );
            
            int randomFruit = Random.Range(0, fruitPrefabs.Length);
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);

            GameObject fruit = Instantiate(fruitPrefabs[randomFruit], spawnPositionFruit, Quaternion.identity);
            spawnedFruits.Add(fruit);

            GameObject enemy = Instantiate(enemyPrefabs[randomEnemy], spawnPositionEnemy, Quaternion.identity);
            spawnedEnemies.Add(enemy);

            EnemyCollision enemyCollision = enemy.GetComponent<EnemyCollision>();
            FruitCollision fruitCollision = fruit.GetComponent<FruitCollision>();
            
            
            if (enemyCollision != null)
            {
                enemyCollision.UpdateSpikeGravity(gravityScale);
            }

            fruit.GetComponent<FruitCollision>().SetReferences(score);
            enemy.GetComponent<EnemyCollision>().SetReferences(playerStatus);
            
            
        }

    }


    public void UpdateSpikeGravity(float newGravityScale)
    {
        gravityScale = newGravityScale;
    }
}
