    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class SpawnScript : MonoBehaviour
    {
        [SerializeField]private Score score;
        [SerializeField]private PlayerStatus playerStatus;
        [SerializeField]private GameDifficulty gameDifficulty;
        
        [SerializeField] private FruitPool fruitPool;
        [SerializeField] private EnemyPool enemyPool;
        
        [SerializeField] private Transform[] spawnPoint;

        private int _startTimer = 3;


        private float _minSpawnInterval = 0.1f;
        private float _maxSpawnInterval = 1.5f; 



        
        private void Start()
        {  
            StartCoroutine(SpawnObjects());
            
            Subscribe(gameDifficulty);
        }

        private void Update()
        {
            StopSpawning();
        }
    
        private void Subscribe(GameDifficulty difficulty)
        {
            difficulty.OnSpawnSpeedChange += DecreaseSpawnInterval;
        }
        public IEnumerator SpawnObjects()
        {
            yield return new WaitForSeconds(_startTimer);

            while (true)
            {
                SpawnEnemy();
                SpawnFruit();
                yield return new WaitForSeconds(Random.Range(_minSpawnInterval, _maxSpawnInterval));
            }
        }            


        public void SpawnFruit()
        {
            int randomIndex = Random.Range(0, spawnPoint.Length);

            GameObject fruitObj = fruitPool.GetPooledObject();

            if (fruitObj == null)
            {
                Debug.LogError("FruitPool -> NULL döndü!");
                return;
            }

            fruitObj.transform.position = spawnPoint[randomIndex].position;
            fruitObj.SetActive(true);

            LittleFruit littleFruit = fruitObj.GetComponent<LittleFruit>();
            if (littleFruit != null)
            {
                littleFruit.SetReferences(score);
            }

            BigFruit bigFruit = fruitObj.GetComponent<BigFruit>();
            if (bigFruit != null)
            {
                bigFruit.SetReferences(score);
            }
        }
        
        public void SpawnEnemy()
        {
            int randomIndex = Random.Range(0, spawnPoint.Length);
            
            GameObject enemyObj = enemyPool.GetPooledObject();

            if (enemyObj != null)
            {
                enemyObj.transform.position = spawnPoint[randomIndex].position;
                
                Enemy enemy = enemyObj.GetComponent<Enemy>();
                
                enemy.SetPlayer(playerStatus);
                enemy.SetDifficulty(gameDifficulty);
                enemyObj.SetActive(true);
                
            }
            
        }
        private void StopSpawning()
        {
            if (playerStatus.IsDead)
            {
                StopAllCoroutines();
            }
        }
        public void DecreaseSpawnInterval(float decreaseSpawnInterval)
        {
            
            _maxSpawnInterval = Mathf.Max(_minSpawnInterval, _maxSpawnInterval - decreaseSpawnInterval);
            Debug.Log("Spawn Interval: "  + _maxSpawnInterval);    
            
        }
    }
