using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shooting : MonoBehaviour
{
    public GameObject projectile;
    public GameObject rocket;
    public GameObject shootingpoint;
    private bool canshoot=true;
    public GameObject munitionb;
    public GameObject rocketb;
    public Image[] munitionbar;
    public Image[] Rocketbar;
    public int maxMunition=16;
    public int munition;
    public int maxMunitionRocket=16;
    public int munitionRocket;

    public float bulletshootTime;
    public float rocketshootTime;

    public int weaponSelected;
    public GameObject[] weapons;
    void Start()
    {
        munitionRocket=maxMunitionRocket;
        munition=maxMunition;
    }

    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
                if(weaponSelected==1&&munition>0)
                {
                    if(canshoot==true)
                {
                    AudioManager.Play("gun");
                    munition=munition-1;
                    Instantiate(projectile,shootingpoint.transform.position,transform.rotation);
                    canshoot=false;
                    StartCoroutine(shoot(bulletshootTime));
                    StartCoroutine(reload(3,1));
                }
                }
                if(weaponSelected==2&&munitionRocket>0)
                {
                    if(canshoot==true)
                {
                    AudioManager.Play("rocket");
                    munitionRocket=munitionRocket-1;
                    Instantiate(rocket,shootingpoint.transform.position,transform.rotation);
                    canshoot=false;
                    StartCoroutine(shoot(rocketshootTime));
                    StartCoroutine(reload(8,2));
                }
                }
            
        }
        for(int i=0; i < munitionbar.Length; i++)
        {
            munitionbar[i].enabled = !DisplayMunition(munition,i);
        }

        for(int i=0; i < Rocketbar.Length; i++)
        {
            Rocketbar[i].enabled = !DisplayMunition(munitionRocket,i);
        }

        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            if(weaponSelected==2)
            {
                weaponSelected=1;
                weapons[1].SetActive(false);
                weapons[0].SetActive(true);
                rocketb.SetActive(false);
                munitionb.SetActive(true);
            }
            else
            {
                weaponSelected=2;
                weapons[0].SetActive(false);
                weapons[1].SetActive(true);
                rocketb.SetActive(true);
                munitionb.SetActive(false);
            }
            
        }
        if(Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            if(weaponSelected==2)
            {
                weaponSelected=1;
                weapons[1].SetActive(false);
                weapons[0].SetActive(true);
                rocketb.SetActive(false);
                munitionb.SetActive(true);
            }
            else
            {
                weaponSelected=2;
                weapons[0].SetActive(false);
                weapons[1].SetActive(true);
                rocketb.SetActive(true);
                munitionb.SetActive(false);
            }
        }
        
    }
     IEnumerator shoot(float shootTime)
    {
        yield return new WaitForSeconds(shootTime);
        canshoot=true;
    }
    IEnumerator reload(float reloadTime,int munitiontype)
    {
        yield return new WaitForSeconds(reloadTime);
        if(munitiontype==1)
        {
            munition+=1;
        }
        if(munitiontype==2)
        {
            munitionRocket+=1;
        }
    }

    bool DisplayMunition(float _munition, int pointNumber)
    {
        return ((pointNumber) >= _munition);
    }
}
