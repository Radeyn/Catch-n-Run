using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;

    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;
    private InputAction _moveAction;

    public bool isMoving {get; private set;}
    public Vector2 moveInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
    }

    private void Start()
    {
        isMoving = false;
    }

    private void Update()
    {
        // Input oku
        moveInput = _moveAction.ReadValue<Vector2>();
        isMoving = moveInput != Vector2.zero;

        // Karakter yönü
        if (moveInput.x < 0)
            transform.localScale = new Vector3(-playerStatus.ScaleX, 1f, 1f);
        else if (moveInput.x > 0)
            transform.localScale = new Vector3(playerStatus.ScaleX, 1f, 1f);
    }

    private void FixedUpdate()
    {
        IsMoving();
    }

    public bool IsMoving()
    {
        Vector2 movement = moveInput.normalized * playerStatus.CurrentSpeed;
        _rigidbody.linearVelocity = movement;
        
        return isMoving = true;
    }

    public void IncreaseSpeed(float amount)
    {
    }
}