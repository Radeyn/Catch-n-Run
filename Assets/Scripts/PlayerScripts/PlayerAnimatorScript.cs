using UnityEngine;

public class PlayerAnimatorScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] PlayerControl playerControl;

    void Start()
    {
        playerControl = GetComponent<PlayerControl>();
    }

    private void Update()
    {
        RunAnimation();
    }
    private void RunAnimation()
    {
        if (playerControl.isMoving != false)
        {
            animator.Play("Run");

        }
    }
}
