using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject particelsystem;

    Collider2D col;
        void Start()
    {
        
    }
    void FixedUpdate()
    {
         transform.position += transform.right * Time.deltaTime * 20;
         Destroy(gameObject, 3.0f);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Ground")
        {
            AudioManager.Play("object_hit");
            Camera.main.GetComponent<Shake>().camshake();
            Instantiate(particelsystem,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
