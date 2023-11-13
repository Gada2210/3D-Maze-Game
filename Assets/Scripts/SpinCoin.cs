using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCoin : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 100f;  // This controls the speed of the rotation. Adjust as needed.

    void Update()
    {
        transform.Rotate(spinSpeed * Time.deltaTime, spinSpeed * Time.deltaTime, spinSpeed * Time.deltaTime); // Rotate the object.
    }
}
