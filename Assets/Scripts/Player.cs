using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] public float playerHealth;
    public float MoveSpeed {get; set;}
    
    private Rigidbody2D _rigidbody;         
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    
    private bool _isMoving;
    public Vector2 moveInput;
    private Animator _animator;
    
    private TextMeshProUGUI _scoreText;
    private TextMeshProUGUI _totalScoreText;
    private GameObject _gameOverUI;
    
    private Vector2 _movement;
    public float scaleX;

    private void Awake()
    {
        GetReferences();
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
        
        _isMoving = moveInput.x != 0 || moveInput.y != 0;

        _animator.SetBool("IsRunning", _isMoving);
        

        if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-scaleX, 8f, 8f); 
        }
        else if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(scaleX, 8f, 8f); 
        }
        
    }

    public void IncreaseSpeed(int moveSpeed)
    {
        
    }
    private void FixedUpdate()
    {
        IsMoving();
      
    }

    public bool IsMoving() 
    {
        moveInput = _moveAction.ReadValue<Vector2>();

        Vector2 movement = moveInput.normalized * MoveSpeed;

        _rigidbody.linearVelocity = movement;

        return _isMoving;
        
    }
    
    private void GetReferences()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        
        _moveAction = _playerInput.actions["Move"];
    }
}
