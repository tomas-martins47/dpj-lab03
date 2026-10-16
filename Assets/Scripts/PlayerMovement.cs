using UnityEngine;
    
public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;
    private InputActions actions;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Animator animator;
    private PlayerAnimations playerAnimations;
    private Player player;

    private void Awake()
    {
        actions = new InputActions();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAnimations = GetComponent<PlayerAnimations>();
        player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        actions.Movement.Enable();
    }

    private void OnDisable()
    {
        actions.Movement.Disable();
    }

    private void ReadMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
    }

    private void Move()
    {
        if (player.Stats.health <= 0) { return; }
        rb.MovePosition(rb.position + moveDirection * (speed * Time.fixedDeltaTime));
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        ReadMovement();
        if (moveDirection == Vector2.zero)
        {
            playerAnimations.SetMoveBoolTransition(false);
            return;
        }
        playerAnimations.SetMoveBoolTransition(true);
        playerAnimations.SetMoveAnimation(moveDirection);
    }
}
