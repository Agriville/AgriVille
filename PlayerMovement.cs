using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // The speed at which the player moves
    public float movementSpeed = 10.0f;

    void Update()
    {
        // Get the horizontal and vertical input axis
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector in the camera's forward direction
        Vector3 movement = (transform.forward * verticalInput + transform.right * horizontalInput) * movementSpeed * Time.deltaTime;

        // Move the player
        transform.position += movement;


    }


   
}