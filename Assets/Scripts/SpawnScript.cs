using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
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


    public IEnumerator SpawnObjects()
    {
        
        while (true)
        {

            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            yield return new WaitForSeconds(spawnInterval);


            int randomIndexFruit = Random.Range(0, spawnPointsFruit.Length);
            int randomIndexEnemy = Random.Range(0, spawnPointsEnemy.Length);
            int randomFruit = Random.Range(0, fruitPrefabs.Length);
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);

            GameObject fruit = Instantiate(fruitPrefabs[randomFruit], spawnPointsFruit[randomIndexFruit].position, Quaternion.identity);
            spawnedFruits.Add(fruit);

            GameObject enemy = Instantiate(enemyPrefabs[randomEnemy], spawnPointsEnemy[randomIndexEnemy].position, Quaternion.identity);
            spawnedEnemies.Add(enemy);

            EnemyCollision enemyCollision = enemy.GetComponent<EnemyCollision>();

            if (enemyCollision != null)
            {
                enemyCollision.UpdateSpikeGravity(gravityScale);
            }


        }

    }


    public void UpdateSpikeGravity(float newGravityScale)
    {
        gravityScale = newGravityScale;
    }
}
