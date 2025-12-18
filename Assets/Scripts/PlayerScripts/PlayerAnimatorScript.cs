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
    }
    private void RunAnimation()
    {
        if (playerMovement.isMoving != false)
        {
            animator.Play("Run");

        }
        else if (playerMovement.isMoving == false)
        {
            animator.Play("Idle");
        }
    }
}
