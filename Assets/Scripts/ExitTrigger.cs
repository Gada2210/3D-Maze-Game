using UnityEngine;
using UnityEngine.Events;

public class ExitTrigger : MonoBehaviour
{
    // Event to be triggered when player hits the exit
    public UnityEvent onPlayerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has hit the exit");
            onPlayerExit?.Invoke();
        }
    }
}
