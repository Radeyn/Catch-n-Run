using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    [SerializeField] private int scoreThreshold = 5;
    private int _nextThreshold = 5;
    
    private PlayerStatus _playerStatus;
    private SpawnScript _spawnScript;
    private Vector2 _moveInput;
    private Score _score;
    private void Start()
    {
        _playerStatus = GetComponent<PlayerStatus>();
        _spawnScript = FindAnyObjectByType<SpawnScript>();
        _score = FindAnyObjectByType<Score>();
    }

    private void Update()
    {
        int score = _score.currentScore;

        if (score >= _nextThreshold)
        {
            
            _playerStatus.DecreaseSpeedPercent(0.1f);
            _spawnScript.DecreaseSpawnInterval(0.1f);
            _spawnScript.IncreaseSpikeGravity(0.25f);
            _nextThreshold += scoreThreshold;

            //_playerStatus.GainWeight(0.5f);
        }

    }

   /* private void MoveDirection()

    {
      
        _playerControl.moveInput = moveInput;


        if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-scaleX, 8f, 8f);
        }

        else if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(scaleX, 8f, 8f);
        }

        
        
    }
*/
  

 

}
