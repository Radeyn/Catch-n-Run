    using System.Collections;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class SpawnScript : MonoBehaviour
    {
        [SerializeField]private Score score;
        [SerializeField]private PlayerStatus playerStatus;
        [SerializeField]private GameDifficulty gameDifficulty;
        
        [SerializeField] private FruitPool fruitPool;
        [SerializeField] private SpikeBallPool spikeBallPool;
        [SerializeField] private SawPool sawPool;
        [SerializeField] private ItemPool itemPool;
        
        [SerializeField] private Transform[] spawnPoint;
        [SerializeField] private Transform[] sawSpawnPoints;

        [SerializeField] private int healthCooldown = 10;
        [SerializeField] private float sawSpawnCooldown = 5f;
        private int _startTimer = 3;
        
        private float _minSpawnInterval = 0.1f;
        private float _maxSpawnInterval = 1.5f; 
        
        private void Start()
        {  
            StartCoroutine(SpawnObjects());
            StartCoroutine(SpawnHealth());
            StartCoroutine(SpawnSawObjects());

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
                SpawnSpikeBall();
                SpawnFruit();
                yield return new WaitForSeconds(Random.Range(_minSpawnInterval, _maxSpawnInterval));

            }
        }

        private IEnumerator SpawnHealth()
        {
            yield return new WaitForSeconds(_startTimer);
            
            while (true)
            {
                SpawnHealthObject();
                
                yield return new WaitForSeconds(healthCooldown);
                
            }
            
        }

        private IEnumerator SpawnSawObjects()
        {
            yield return new WaitForSeconds(_startTimer);

            yield return new WaitUntil(() => score.score >= 2000);
            while (true)
            {
                SpawnSaw();

                yield return new WaitForSeconds(sawSpawnCooldown);
            }       
        }


    private void SpawnFruit()
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
                littleFruit.SetPlayer(playerStatus);
        }

            BigFruit bigFruit = fruitObj.GetComponent<BigFruit>();
            if (bigFruit != null)
            {
                bigFruit.SetReferences(score);
                bigFruit.SetPlayer(playerStatus);
            }
        }
        
        private void SpawnSpikeBall()
        {
            int randomIndex = Random.Range(0, spawnPoint.Length);
            
            GameObject spikeBallObj = spikeBallPool.GetPooledObject();

            if (spikeBallObj != null)
            {
                spikeBallObj.transform.position = spawnPoint[randomIndex].position;
                
                SpikeBall spikeBall = spikeBallObj.GetComponent<SpikeBall>();
                
                spikeBall.SetPlayer(playerStatus);
                spikeBall.SetDifficulty(gameDifficulty);
                spikeBall.SetScore(score);
                spikeBallObj.SetActive(true);
                
            }
            
        } 

        private void SpawnSaw()
        {
            int randomIndex = Random.Range(0, sawSpawnPoints.Length);
            
            GameObject sawObj = sawPool.GetPooledObject();

            if(sawObj != null)
            {              
                sawObj.transform.position = sawSpawnPoints[randomIndex].position;

                Saw saw = sawObj.GetComponent<Saw>();

                saw.SetDirection(randomIndex);
                saw.SetPlayer(playerStatus);
                sawObj.SetActive(true);
             }

        }
        private void SpawnHealthObject()
            {
                int randomIndex = Random.Range(0, spawnPoint.Length);
            
                GameObject healthObj = itemPool.GetPooledObject();

                if (healthObj != null && playerStatus.CurrentHealth < 4)
                {
                    healthObj.transform.position = spawnPoint[randomIndex].position;
                
                    HealthScript healItem = healthObj.GetComponent<HealthScript>();
                
                    healItem.SetPlayer(playerStatus);
                    healthObj.SetActive(true);
                
                }
            
            }
        
        
        private void StopSpawning()
        {
            if (playerStatus.IsDead)
            {
                StopAllCoroutines();
            }
        }
        private void DecreaseSpawnInterval(float decreaseSpawnInterval)
        {
            
            _maxSpawnInterval = Mathf.Max(_minSpawnInterval, _maxSpawnInterval - decreaseSpawnInterval);
            Debug.Log("Spawn Interval: "  + _maxSpawnInterval);    
            
        }
    }
