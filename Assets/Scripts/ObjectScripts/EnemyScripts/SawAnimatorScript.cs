using UnityEngine;

public class SawAnimatorScript : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {   
        if (gameObject.activeInHierarchy)
        {
            animator.Play("SawOn");
        }
    }
}
