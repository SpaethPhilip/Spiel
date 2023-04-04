using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collsio : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Ground"&&GetComponentInParent<PlayerMovement>().isDashing==true)
        {
            Camera.main.GetComponent<Shake>().explosion();
            Destroy(gameObject);
        }
    }
}
