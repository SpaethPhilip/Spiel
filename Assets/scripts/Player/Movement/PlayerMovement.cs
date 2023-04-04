using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //Dash
    public  float dashCoolDown = 5;
    public  bool cooledDown =true;
    public float dashSpeed;
    public float dashTime=1;
    public bool isDashing;
    //Movement
    public Rigidbody2D rb;
    public float moveSpeed;
    private Vector2 moveDirection;

    public TrailRenderer tr;
    public Image dashbar;
    float timer;
    float lerpSpeed;

    void Start()
    {
        timer=dashCoolDown;
    }
    void Update()
    {
        Processinput();

    }
    private void FixedUpdate() 
    {
        Move();
        if (timer < dashCoolDown)
        {
            timer += Time.deltaTime;
        }
        lerpSpeed = 3f*Time.deltaTime;
        dashbar.fillAmount= Mathf.Lerp(dashbar.fillAmount,timer/dashCoolDown,lerpSpeed);
        
            Color dashbarColor = Color.Lerp(Color.gray, Color.blue,(timer/dashCoolDown));
            dashbar.color = dashbarColor;
    }

    void Processinput()
    {
        //get key input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        
        if(Input.GetButton("Dash")&&cooledDown==true)
        {
            StartCoroutine(DashTimer());
        }
    }
    void Move()
    {
        //Dahing
        if(isDashing==true)
        {
            GetComponent<BoxCollider2D>().isTrigger=true;
            rb.velocity = new Vector2(moveDirection.x *dashSpeed,moveDirection.y*dashSpeed);
        }
        //not Dashing
        else
        {
            GetComponent<BoxCollider2D>().isTrigger=false;
            rb.velocity = new Vector2(moveDirection.x *moveSpeed,moveDirection.y*moveSpeed);
        }
    }
    IEnumerator DashTimer()
    {
        isDashing=true;
        tr.emitting=true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting=false;
        isDashing=false;
        StartCoroutine(CoolDown());
        timer=0;
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(dashCoolDown);
        timer=dashCoolDown;
        cooledDown=true;
    }
}
