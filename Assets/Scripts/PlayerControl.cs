using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    
    
    private Rigidbody2D _rigidbody;         
    private PlayerInput _playerInput;
    private InputAction _moveAction;

    public bool isMoving;
    public Vector2 moveInput;
    
    
    private Vector2 _movement;
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
        isMoving = moveInput.x != 0 || moveInput.y != 0;

        if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-playerStatus.ScaleX, 8f, 8f); 
        }
        else if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(playerStatus.ScaleX, 8f, 8f); 
        }
        
    }

    public void IncreaseSpeed(int moveSpeed)
    {
        
    }
    // ReSharper disable Unity.PerformanceAnalysis
    public bool IsMoving() 
    {
        moveInput = _moveAction.ReadValue<Vector2>();

        var movement = moveInput.normalized * playerStatus.CurrentSpeed;

        _rigidbody.linearVelocity = movement;

        return isMoving;
        
    }
    
    private void GetReferences()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        
        _moveAction = _playerInput.actions["Move"];
    }
}
