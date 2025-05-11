using UnityEngine;

public class Player : MonoBehaviour
{
    InputReader input;
    CharacterController controller;
    Vector3 direction;

    Vector3 yVelocity;

    [SerializeField] float speed = 8f;

    [SerializeField] float gravityScale = 2f;
    [SerializeField] float jumpHeight = 1.5f;
    bool jumpPressed;

    private void Awake()
    {
        input = GetComponent<InputReader>();
        controller = GetComponent<CharacterController>();

        input.jumpPressed += OnJump;
    }

    private void OnDisable()
    {
        input.jumpPressed -= OnJump;
    }

    private void Update()
    {
        Vector2 moveInput = input.MoveInput;
        direction = transform.forward * moveInput.y + transform.right * moveInput.x;
        // These don't affect the y-axis at all

        HandleGravity();

        Vector3 velocity = direction * speed;
        velocity += yVelocity;

        controller.Move(velocity * Time.deltaTime);
    }

    void HandleGravity()
    {
        if (controller.isGrounded)
        {
            if (jumpPressed) return;
            yVelocity.y = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            jumpPressed = false;
            yVelocity.y += Physics.gravity.y* gravityScale * Time.deltaTime;
        }
    }

    void OnJump()
    {
        if (!controller.isGrounded) return;
        jumpPressed = true;
        yVelocity.y = Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight * gravityScale);
    }
}
