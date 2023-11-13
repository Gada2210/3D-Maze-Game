using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private SceneRotator sceneRotator;
    [SerializeField] private MovementControl movementController;
    [SerializeField] private CameraController cameraController;

    private CSE3541Inputs inputScheme;

    private void Awake()
    {
        inputScheme = new CSE3541Inputs();
        movementController.Initialize(inputScheme.Player.Move);
        cameraController.Initialize(inputScheme.Player.Look);

        // Initialize the scene rotator with the Rotate action
        sceneRotator.Initialize(inputScheme.Gameplay.Rotate);
    }

    private void OnEnable()
{
    // Enable the input scheme when the object is enabled
    if (inputScheme != null)
    {
        inputScheme.Enable();
    }
}

private void OnDisable()
{
    // Disable the input scheme when the object is disabled
    if (inputScheme != null)
    {
        inputScheme.Disable();
    }
}

}
