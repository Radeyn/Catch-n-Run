using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private bool isMoving;
    public Animator animator;
    public float playerHealth;
    public Vector2 moveInput;
    public float moveSpeed = 5f;
    public int score;
    public GameObject gameOverUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI totalScoreText;
    private Vector2 movement;



    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

 
    private void Update()
    {
        
        isMoving = moveInput.x != 0 || moveInput.y != 0;

        animator.SetBool("IsRunning", isMoving);

        UpdateScoreText();



        if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-8f, 8f, 8f); 
        }
        else if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(8f, 8f, 8f); 
        }


       
    }

    private void FixedUpdate()
    {
        IsMoving();
      
    }

    public bool IsMoving() 
    {
        moveInput = moveAction.ReadValue<Vector2>();

        Vector2 movement = moveInput.normalized * moveSpeed;

        rb.linearVelocity = movement;

        return isMoving;


    }

    private void UpdateScoreText()
    {
        scoreText.text = "SCORE: " + score.ToString(); 
        totalScoreText.text = "TOTAL SCORE: " + score.ToString(); 

    }
}
