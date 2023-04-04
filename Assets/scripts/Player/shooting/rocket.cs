using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    public GameObject particelsystem;
    Collider2D col;
        void Start()
    {
        
    }
    void FixedUpdate()
    {
         transform.position += transform.right * Time.deltaTime * 13;
         Destroy(gameObject, 3.0f);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Ground")
        {
            AudioManager.Stop("rocket(Clone)");
            AudioManager.Play("explosion");
            Camera.main.GetComponent<Shake>().explosion();
            Instantiate(particelsystem,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
