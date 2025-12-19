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
    }
    private void RunAnimation()
    {
        if (playerMovement.isMoving != false && playerMovement.IsGrounded())
        {
            animator.Play("Run");

        }
        else if (playerMovement.isMoving == false && playerMovement.IsGrounded())
        {
            animator.Play("Idle");
        }
    }

    private void JumpAnimation()
    {
        if (playerMovement.IsGrounded() == false)
        {
            animator.Play("Jump");
        }
        else 
        {
            // Do nothing, let RunAnimation handle the state
        }
    }
}
