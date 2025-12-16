using UnityEngine;

public class PlayerAnimatorScript : MonoBehaviour
{
    private Animator animator;
    public PlayerControl playerControl;

    void Start()
    {
        playerControl = GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
