using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private float sensitivity = 100.0f;
    [SerializeField] private float maxRotationSpeed = 100.0f;
    [SerializeField] private float cameraSpeed = 1.0f;
    [SerializeField] private float minYAngle = -60f; // The minimum vertical angle the camera can rotate
    [SerializeField] private float maxYAngle = 60f; // The maximum vertical angle the camera can rotate

    private Vector3 offset; // Stores the initial offset between the camera and player

    private InputAction lookAction;
    private Vector2 lookInput;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    public void Initialize(InputAction lookAction)
    {
        this.lookAction = lookAction;
        this.lookAction.Enable();

        this.lookAction.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        this.lookAction.canceled += ctx => lookInput = Vector2.zero;

        // Calculate the initial offset between the player and the camera
        offset = transform.position - targetObject.transform.position;
    }

    private void Update()
    {
        // Calculate new euler angles
        var mouseX = lookInput.x * sensitivity * Time.deltaTime;
        var mouseY = lookInput.y * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minYAngle, maxYAngle);
        yRotation += mouseX;

        // Apply rotation to the camera
        var targetRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxRotationSpeed * Time.deltaTime);

        // Move camera smoothly to the target
        Vector3 targetPosition = targetObject.transform.position + offset; // Calculate the desired camera position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }
}


