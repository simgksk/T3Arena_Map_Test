using System;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float mouseSensitivity = 50f;
    public Transform cameraTransform;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        LookAround();
        Move();
    }

    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 상하 회전 (Pitch)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); 

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 좌우 회전 (Yaw)
        transform.Rotate(Vector3.up * mouseX);
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");   

        Vector3 direction = transform.right * horizontal + transform.forward * vertical;

        transform.position += direction.normalized * moveSpeed * Time.deltaTime;
    }
}
