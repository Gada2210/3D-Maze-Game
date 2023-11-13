using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobCoin : MonoBehaviour
{
    public float bobbingSpeed = 0.2f;
    public float bobbingAmount = 0.25f;  // Half of the total desired bobbing distance
    private float defaultY;
    private float timer = 0.0f;

    void Start()
    {
        defaultY = transform.position.y;
    }

    void Update()
    {
        timer += Time.deltaTime * bobbingSpeed;
        if (timer > Mathf.PI * 2) // reset timer to keep it manageable
        {
            timer -= Mathf.PI * 2;
        }

        // Calculate bobbing offset based on Sin function
        float bobbingOffset = Mathf.Sin(timer) * bobbingAmount;
        
        // Apply bobbing offset to default y position
        transform.position = new Vector3(transform.position.x, defaultY + bobbingOffset, transform.position.z);
    }
}
