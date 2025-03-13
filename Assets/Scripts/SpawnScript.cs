using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform[] spawnPointsFruit; // Burayı public yapıyoruz
    public Transform[] spawnPointsEnemy; // Burayı public yapıyoruz
    public GameObject[] fruitPrefabs;
    public GameObject[] enemyPrefabs;
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


            int randomIndexFruit = Random.Range(0, spawnPointsFruit.Length);
            int randomIndexEnemy = Random.Range(0, spawnPointsEnemy.Length);
            int randomFruit = Random.Range(0, fruitPrefabs.Length);
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);

            GameObject fruit = Instantiate(fruitPrefabs[randomFruit], spawnPointsFruit[randomIndexFruit].position, Quaternion.identity);
            spawnedFruits.Add(fruit);

            GameObject enemy = Instantiate(enemyPrefabs[randomEnemy], spawnPointsEnemy[randomIndexEnemy].position, Quaternion.identity);
            spawnedEnemies.Add(enemy);


        }
    }
}
