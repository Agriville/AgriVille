using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float zoomSpeed = 1.0f;

    void Update()
{
    if (Input.GetMouseButton(1))
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 movement = new Vector3(mouseX, 0, mouseY) * movementSpeed * Time.deltaTime;

        transform.position += movement;
    }

    float scroll = Input.GetAxis("Mouse ScrollWheel");
    if (scroll != 0)
    {
        transform.position += transform.forward * scroll * zoomSpeed * Time.deltaTime;
    }
}
}
