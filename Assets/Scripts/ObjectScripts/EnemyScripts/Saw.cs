using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    private PlayerStatus _playerStatus;

    [SerializeField] int sawDamage = 1;

    [SerializeField] float speed = 20f;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector2 boxSize;
    [SerializeField] float castDistance;

    private bool isGoingRight;

    private void Update()
    {
        IsHoveringGround();
        DisableSaw();
    }
    private void FixedUpdate()
    {
        MoveSaw();
    }
    public void SetPlayer(PlayerStatus playerStatus)
    {
        _playerStatus = playerStatus;
    }
    public void SetDirection(int spawnIndex)
    {
        if (spawnIndex == 0)
        {
            rb.linearVelocity = Vector2.right * speed;
            isGoingRight = true;
        }
        else 
        {
            rb.linearVelocity = Vector2.left * speed;
            isGoingRight = false;
        }
        
        
    }

   private void MoveSaw()
    {
        if (isGoingRight)
        {
            rb.linearVelocity = Vector2.right * speed;
        }
        else
        {
            rb.linearVelocity = Vector2.left * speed;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerStatus.TakeDamage(sawDamage);
        }
    }
    private void DisableSaw()
    {
        if(!IsHoveringGround())
        {
            gameObject.SetActive(false);
        }
    }

    private bool IsHoveringGround()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0f, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + -transform.up * castDistance, boxSize);
    }


}
