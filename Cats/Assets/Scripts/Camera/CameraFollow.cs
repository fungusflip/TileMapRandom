using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target to follow (usually the player)
    public float followSpeed = 5f; // The speed at which the camera follows the target
    public Vector2 minBounds; // The minimum camera position
    public Vector2 maxBounds; // The maximum camera position

    public float zoomSpeed = 1.0f; // Adjust this value to control zoom speed
    public float minZoomSize = 1.0f; // Minimum zoom size
    public float maxZoomSize = 10.0f; // Maximum zoom size

    void Start()
    {
        Camera camera = GetComponent<Camera>();
    }
    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Adjust the camera size based on scroll input
        
        float newSize = GetComponent<Camera>().orthographicSize - scrollInput * zoomSpeed;

        // Clamp the zoom size to the min and max values
        newSize = Mathf.Clamp(newSize, minZoomSize, maxZoomSize);

        // Update the camera's orthographic size
        GetComponent<Camera>().orthographicSize = newSize;
    }
    private void FixedUpdate()
    {
            // Calculate the target position
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Smoothly interpolate the camera's position towards the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            // Clamp the camera position within the specified bounds
            float clampedX = Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x);
            float clampedY = Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        
    }
}