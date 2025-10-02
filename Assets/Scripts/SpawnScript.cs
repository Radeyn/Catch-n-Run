    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SpawnScript : MonoBehaviour
    {
        [SerializeField]private Score score;
        [SerializeField]private PlayerStatus playerStatus;
        [SerializeField]private GameObject spawnPosition;

        private int _startTimer = 3;
        private float _spikeGravityScale = 1f;

        public Transform[] spawnPointsFruit; 
        public Transform[] spawnPointsEnemy; 
        public GameObject[] fruitPrefabs;
        public GameObject[] enemyPrefabs;

        private float _minSpawnInterval = 0.1f;
        private float _maxSpawnInterval = 1.5f; 

        public List<GameObject> spawnedEnemies = new List<GameObject>();
        public List<GameObject> spawnedFruits = new List<GameObject>();


        
        private void Start()
        {  
            GetComponent<Rigidbody2D>();
            
        }

        public IEnumerator DelayedStart()
        {
            yield return new WaitForSeconds(_startTimer);
            StartCoroutine(SpawnObjects());

        }


        // ReSharper disable Unity.PerformanceAnalysis
        private IEnumerator SpawnObjects()
        {
            
            while (true)
            {

                float spawnInterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);

                yield return new WaitForSeconds(spawnInterval);

                Vector2 spawnPositionEnemy = new Vector2(
                    Random.Range((float)-15, 15),
                    Random.Range((float)16, 25)

                );
                
                Vector2 spawnPositionFruit = new Vector2(
                    Random.Range((float)-16, 16),
                    Random.Range((float)16, 25)

                );
                
                int randomFruit = Random.Range(0, fruitPrefabs.Length);
                int randomEnemy = Random.Range(0, enemyPrefabs.Length);

                GameObject fruit = Instantiate(fruitPrefabs[randomFruit], spawnPositionFruit, Quaternion.identity);
                spawnedFruits.Add(fruit);

                GameObject enemy = Instantiate(enemyPrefabs[randomEnemy], spawnPositionEnemy, Quaternion.identity);
                spawnedEnemies.Add(enemy);

                EnemyCollision enemyCollision = enemy.GetComponent<EnemyCollision>();
                FruitCollision fruitCollision = fruit.GetComponent<FruitCollision>();
                
                
                fruit.GetComponent<FruitCollision>().SetReferences(score);
                enemy.GetComponent<EnemyCollision>().SetReferences(playerStatus);
                
                Rigidbody2D fruitRb = fruit.GetComponent<Rigidbody2D>();
                Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
                
                if (fruitRb != null) fruitRb.gravityScale = _spikeGravityScale;
                if (enemyRb != null) enemyRb.gravityScale = _spikeGravityScale;
            }

        }

        public void DecreaseSpawnInterval(float amount)
        {
            _maxSpawnInterval = Mathf.Max(_minSpawnInterval, _maxSpawnInterval - amount);
            Debug.Log("MaxSpawnInterval: " + _maxSpawnInterval);
        }
        public void IncreaseSpikeGravity(float amount)
        {
            _spikeGravityScale += amount;
            Debug.Log("gravity scale" + _spikeGravityScale);
        }

        public void ResetSpikeGravity()
        {
            _spikeGravityScale = 1f;
        }

        public void ResetSpawnInterval()
        {
            _maxSpawnInterval = 1.5f;
        }
    }
