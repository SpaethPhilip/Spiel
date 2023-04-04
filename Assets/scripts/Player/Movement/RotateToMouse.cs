using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    private float speed = 5f;
    public float angle;
    public double rotation;
    // Update is called once per frame
    private void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition)- transform.position;
        angle = Mathf.Atan2(direction.y,direction.x)* Mathf.Rad2Deg;
        Quaternion rotaion = Quaternion.AngleAxis(angle,Vector3.forward);
        transform.rotation= Quaternion.Slerp(transform.rotation,rotaion,speed*Time.deltaTime);
        rotation= transform.localEulerAngles.z;
    }
}
