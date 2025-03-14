using UnityEngine;

public class PlayerAnimatorScript : MonoBehaviour
{

    private Animator animator;
    public Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
