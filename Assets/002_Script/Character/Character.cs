using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform cameraTransform;
    private Vector3 moveDirection;
    private bool isRightClicking = false;

    void Update()
    {
        HandleMovement();
        HandleCameraRotation();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        if (moveDirection.magnitude > 0)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }

    void HandleCameraRotation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRightClicking = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRightClicking = false;
        }

        if (isRightClicking)
        {
            float mouseX = Input.GetAxis("Mouse X") * 3f;
            float mouseY = Input.GetAxis("Mouse Y") * 3f;

            cameraTransform.Rotate(Vector3.up * mouseX, Space.World);
            cameraTransform.Rotate(Vector3.right * -mouseY, Space.Self);
        }
    }
}
