using UnityEngine;

public class PlayerAnimatorScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        RunAnimation();
        JumpAnimation();
        FallAnimation();
    }
    private void RunAnimation()
    {
        if (playerMovement.isMoving && playerMovement.IsGrounded())
        {
            animator.Play("Run");

        }
        else if (!playerMovement.isMoving && playerMovement.IsGrounded())
        {
            animator.Play("Idle");
        }
    }

    private void JumpAnimation()
    {
        if (!playerMovement.IsGrounded() && !playerMovement.IsFalling())
        {
            animator.Play("Jump");
        }
        else
        {
            // Do nothing, let RunAnimation handle the state
        }
    }

    private void FallAnimation()
    {
        if (playerMovement.IsFalling() && !playerMovement.IsGrounded())
        {
            animator.Play("Fall");
        }
    }
}
