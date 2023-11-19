using UnityEngine;

public class RotateAndMove : MonoBehaviour
{
    public Transform rotationObject; // Reference to the object whose rotation determines the movement
    public float moveSpeed = 1f; // Speed at which the object moves
    public float maxZMovement = 5f; // Maximum allowed movement in the Z direction
    public float maxZMovementplus = 5f; // Maximum allowed movement in the Z direction

    private float initialRotationZ; // Initial rotation of the rotationObject
    private float totalRotation; // Cumulative rotation of the rotationObject

    private void Start()
    {
        // Store the initial rotation of the rotationObject
        initialRotationZ = rotationObject.eulerAngles.z;
        totalRotation = 0f;
    }

    private void Update()
    {
        // Calculate the current rotation difference from the initial rotation
        float rotationDifference = rotationObject.eulerAngles.z - initialRotationZ;

        // Calculate the difference in cumulative rotation
        float cumulativeRotation = rotationDifference + totalRotation;

        // Calculate the movement amount based on the cumulative rotation
        float moveAmount = cumulativeRotation * moveSpeed * Mathf.Sign(rotationDifference);

        // Update the total rotation
        totalRotation += rotationDifference;

        // Calculate the clamped Z position based on the maximum allowed movement
        float clampedZ = Mathf.Clamp(transform.position.z + moveAmount * Time.deltaTime, -maxZMovement, maxZMovementplus);

        // Move the object in the Z direction with the correct sign based on rotation direction
        transform.position = new Vector3(transform.position.x, transform.position.y, clampedZ );
    }
}
