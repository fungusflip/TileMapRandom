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
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dex = PlayerPrefs.GetFloat("DEX");
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
    }
}

