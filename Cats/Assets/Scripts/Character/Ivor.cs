using UnityEngine;

public class Ivor : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float maxWalkingSpeed = 3f;
    private float maxRunningSpeed;
    private float walkingAcceleration = 2f;
    private float runningAcceleration = 8f;
    private float currentSpeed;
    private bool isRunning = false;
    private SpriteRenderer spriteRenderer;
    private bool isFacingRight = true;
    [SerializeField] private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FlipSpriteDirection(Input.GetAxis("Horizontal"));
        float dex = PlayerPrefs.GetFloat("DEX");
        
        animator.SetBool("Walk", isRunning);
        animator.SetFloat("Speed", Mathf.Abs(currentSpeed));
        maxRunningSpeed = maxWalkingSpeed + Mathf.Floor(dex / 5);

        float targetSpeed = Mathf.Clamp(dex, 0f, isRunning ? maxRunningSpeed : maxWalkingSpeed);
        float acceleration = isRunning ? runningAcceleration : walkingAcceleration;
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

        Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidBody.velocity = currentSpeed * movementDirection;

        if (rigidBody.velocity.magnitude == 0)
        {
            currentSpeed = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && dex > 3) {
            isRunning = true;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            isRunning = false;
        }
        Debug.Log(currentSpeed);
        Debug.Log(isRunning);
    }
    
    
    void FlipSpriteDirection(float horizontalInput)
    {
        // Check if the character is moving to the right or left
        if (horizontalInput > 0 && !isFacingRight || horizontalInput < 0 && isFacingRight)
        {
            // Toggle the facing direction
            isFacingRight = !isFacingRight;

            // Flip the sprite by changing the localScale's x value
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }
}

