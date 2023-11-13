using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MovementControl : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameObject playerToMove;
    [SerializeField] private float speed = 5f;
    [SerializeField] TextMeshProUGUI coinTexts; // Change this to Text
    private InputAction moveAction;
    public int coins;
    
    public void Initialize(InputAction moveAction)
    {
        this.moveAction = moveAction;
        //Debug.Log(moveAction);
        moveAction.Enable();
    }

    private void FixedUpdate()
    {
        //Debug.Log(moveAction);
        Vector2 movement = moveAction.ReadValue<Vector2>();
        
        Vector3 direction = (playerCamera.transform.forward * movement.y + playerCamera.transform.right * movement.x).normalized;
        direction.y = 0f; // to prevent the player from flying into the sky

        playerToMove.transform.position += direction * speed * Time.fixedDeltaTime;
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Coin")
        {
            Debug.Log("Coin Collected");
            coins++;
            coinTexts.text = "Coins: " + coins.ToString(); // Update the displayed coin count
            Destroy(col.gameObject);
        }
    }
}
