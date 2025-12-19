using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 20f;
    [SerializeField] float fallingForce = 5f;

    [SerializeField] float horizontalInput;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector2 boxSize;
    [SerializeField] float castDistance;

    public bool isMoving {get ; private set; }

    private void Update()
    {
        TurnAround();
        IsGrounded();
    }
    private void FixedUpdate()
    {
        MovePlayer();
        IsMoving();
        Falling();
    }

    #region Movement
    public void Move(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
    }

    private void TurnAround()
    {
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

    private void MovePlayer()
    {
        if(IsGrounded())
        {
            rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(horizontalInput * (moveSpeed / 1.5f), rb.linearVelocity.y);
        }
    }

    private void IsMoving()
    {
        if (horizontalInput != 0)
        {
            isMoving = true;

        }
        else if (horizontalInput == 0)
        {
            isMoving = false;
        }

    }
    #endregion

    #region Jumping

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public bool IsGrounded()
    {
       
        if(Physics2D.BoxCast(transform.position, boxSize, 0f, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private void Falling()
    {
        if (!IsGrounded())
        {
            rb.AddForce(Vector2.down * fallingForce);
        }
    }

    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + -transform.up * castDistance, boxSize);
    }
}
