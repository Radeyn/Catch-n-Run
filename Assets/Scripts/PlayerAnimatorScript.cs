using UnityEngine;

public class PlayerAnimatorScript : MonoBehaviour
{

    private Animator animator;
    public PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
