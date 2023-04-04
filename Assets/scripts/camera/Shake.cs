using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator anim;
    public void camshake()
    {
        anim.SetTrigger("Shake");
    }
    public void explosion()
    {
        anim.SetTrigger("explosion");
    }
}
