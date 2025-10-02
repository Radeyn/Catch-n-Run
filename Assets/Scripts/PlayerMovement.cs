using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed {get; set;}
    private Rigidbody2D _rigidbody;         
    private PlayerInput _playerInput;
    private InputAction _moveAction;

    public bool _isMoving;
    public Vector2 moveInput;
    
    
    private Vector2 _movement;
    public float scaleX;
    private bool _b;

    private void Start()
    {
        _b = IsMoving();
    }

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
    // ReSharper disable Unity.PerformanceAnalysis
    public bool IsMoving() 
    {
        moveInput = _moveAction.ReadValue<Vector2>();

        var movement = moveInput.normalized * MoveSpeed;

        _rigidbody.linearVelocity = movement;

        return _isMoving;
        
    }
    
    private void GetReferences()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        
        _moveAction = _playerInput.actions["Move"];
    }
}
