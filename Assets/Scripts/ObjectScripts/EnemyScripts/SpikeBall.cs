using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SpikeBall : MonoBehaviour
{
    private GameDifficulty gameDifficulty;
    private Score _score;
    private PlayerStatus player;
    private Rigidbody2D _rigidbody;
    private float baseGravity= 1f;

    [SerializeField] GameObject floatingTextPrefab;
    [SerializeField] LayerMask playerMask;
    [SerializeField] float closeCallDistance = 1.5f;
    [SerializeField] float closeCallScore = 30f;
    [SerializeField] float rayHeightOffset;

    Vector2[] directions = { Vector2.right, Vector2.left };

    public bool hitPlayer;
    public bool closeCallGiven;


    private void OnEnable()
    {
        hitPlayer = false;
        closeCallGiven = false;
    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        CloseCall();
    }
    public void SetPlayer(PlayerStatus playerStatus)
    {
        player = playerStatus;
    }
    public void SetScore(Score score)
    {
        _score = score;
    }
    public void SetDifficulty(GameDifficulty difficulty)
    {
        gameDifficulty = difficulty;
        difficulty.OnSpikeSpeedChange += UpdateSpikeGravity;
        
    }
    private void InstantiateFloatingText()
    {
        var text = Instantiate(floatingTextPrefab, player.transform.position, Quaternion.identity);

        text.GetComponent<TextMeshPro>().text = ("Close Call! " + "+" + closeCallScore.ToString());
        text.GetComponent<TextMeshPro>().color = Color.black;
        text.GetComponent<TextMeshPro>().fontSize = 24;
    }
    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                hitPlayer = true;
                player.TakeDamage(1);
                
                gameObject.SetActive(false);

                Debug.Log("Player Health: " + player.CurrentHealth);
            }
            
            else if (collision.gameObject.CompareTag("Floor"))
            {
                gameObject.SetActive(false);
            }

        }

    private void CloseCall()
    {
        Vector2 rayOrigin = (Vector2)transform.position + Vector2.up * rayHeightOffset;

        foreach (Vector2 direction in directions)
        {
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, direction, closeCallDistance, playerMask);
            if (hit.collider != null && !closeCallGiven && !hitPlayer)
            {
                closeCallGiven = true;
                InstantiateFloatingText();
                _score.AddScore(closeCallScore);
                Debug.Log("Close Call");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector2 rayOrigin = (Vector2)transform.position + Vector2.up * rayHeightOffset;

        foreach (Vector2 direction in directions)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(rayOrigin, rayOrigin + direction * closeCallDistance);
        }
        
    }
    private void UpdateSpikeGravity(float decreaseSpawnInterval)
        {
            _rigidbody.gravityScale = baseGravity * decreaseSpawnInterval;
            Debug.Log("Gravity Scale: " + _rigidbody.gravityScale);
        }

   
}