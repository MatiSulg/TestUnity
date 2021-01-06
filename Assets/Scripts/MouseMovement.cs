using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 20f;

    public Transform playerBody;

    float xRotation = 0f;
    float yRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, 30f, 150f);

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -20f, 10f);

        playerBody.transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
    }
}
