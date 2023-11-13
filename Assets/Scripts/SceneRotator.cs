using UnityEngine;
using UnityEngine.InputSystem;

public class SceneRotator : MonoBehaviour
{
    public float rotationSpeed = 20f;
    private bool isRotating = false;
    private Vector3 center;
    private InputAction rotateAction;

    public void Initialize(InputAction rotateAction)
    {
        this.rotateAction = rotateAction;
        this.rotateAction.performed += ctx => ToggleRotation();
        this.rotateAction.Enable();

        // Calculate the center of the maze
        CalculateCenterOfMaze();

        // Debug output
        Debug.Log("Center of maze: " + center);
    }

    private void CalculateCenterOfMaze()
    {
        Vector3 sumVector = new Vector3(0f, 0f, 0f);
        int childCount = 0;

        foreach (Transform child in transform)
        {
            sumVector += child.position;
            childCount++;
        }

        center = sumVector / childCount;
    }

    private void ToggleRotation()
    {
        isRotating = !isRotating;
    }

    void Update()
    {
        if (isRotating)
        {
            // Rotate around the center of the maze
            transform.RotateAround(center, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
