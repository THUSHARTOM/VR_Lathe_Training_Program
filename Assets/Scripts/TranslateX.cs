using UnityEngine;

public class RotateAndMoveX : MonoBehaviour
{
    public Transform rotationObject; // Reference to the object whose rotation determines the movement
    public float moveSpeed = 1f; // Speed at which the object moves
    public float maxXMovement = 5f; // Maximum allowed movement in the X direction
    public float maxXMovementplus = 5f; // Maximum allowed movement in the X direction\

    private float initialRotationX; // Initial rotation of the rotationObject
    private float totalRotation; // Cumulative rotation of the rotationObject

    private void Start()
    {
        // Store the initial rotation of the rotationObject
        initialRotationX = rotationObject.eulerAngles.x;
        totalRotation = 0f;
    }

    private void Update()
    {
        // Calculate the current rotation difference from the initial rotation
        float rotationDifference = rotationObject.eulerAngles.x - initialRotationX;

        // Calculate the difference in cumulative rotation
        float cumulativeRotation = rotationDifference + totalRotation;

        // Calculate the movement amount based on the cumulative rotation and rotation direction
        float moveAmount = cumulativeRotation * moveSpeed * Mathf.Sign(rotationDifference);

        // Update the total rotation
        totalRotation += rotationDifference;

        // Calculate the clamped X position based on the maximum allowed movement
        float clampedX = Mathf.Clamp(transform.position.x + moveAmount * Time.deltaTime, -maxXMovement, maxXMovementplus);

        // Move the object in the X direction
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}