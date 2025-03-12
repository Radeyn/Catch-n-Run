using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform[] spawnPoints; // Burayı public yapıyoruz
    public GameObject[] fruitPrefabs;
    public GameObject[] enemyPrefabs;
    public float spawnInterval = 0.5f;
    private int startTimer = 3;
    public float minSpawnInterval = 0.3f; // Minumum spawn aralığı
    public float maxSpawnInterval = 1.5f; // Maximum spawn aralığı

    public List<GameObject> spawnedEnemies = new List<GameObject>();
    public List<GameObject> spawnedFruits = new List<GameObject>();
   
    private void Start()
    {  
        rb = GetComponent<Rigidbody2D>();

       // StartCoroutine(DelayedStart());
        

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


            int randomIndex = Random.Range(0, spawnPoints.Length);
            int randomFruit = Random.Range(0, fruitPrefabs.Length);
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);

            GameObject fruit = Instantiate(fruitPrefabs[randomFruit], spawnPoints[randomIndex].position, Quaternion.identity);
            spawnedFruits.Add(fruit);

            GameObject enemy = Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomIndex].position, Quaternion.identity);
            spawnedEnemies.Add(enemy);


        }
    }
}
