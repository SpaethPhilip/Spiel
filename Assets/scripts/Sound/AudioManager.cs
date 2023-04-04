using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    AudioSource s;
    public GameObject[] sounds;
    private void Update() 
    {
        sounds = GameObject.FindGameObjectsWithTag("Sound");

        for(int i=0;sounds.Length>i;i++)
        {
            s = sounds[i].GetComponent<AudioSource>();
            if(!s.isPlaying==true)
            {
                string n = sounds[i].name;
                
                GameObject go = GameObject.Find (n);
                if (go){
                    Destroy (go.gameObject);
                }
     
            }
        }
    }

    static public bool Play(string name)
    {
        UnityEngine.Object prefab = Resources.Load("Prefabs/Sounds/"+ name);
        Instantiate(prefab);
        return true;
    }
    static public void Stop(string name)
    {      
        GameObject go = GameObject.Find (name);

        if (go){
            Destroy (go.gameObject);
        }
    }
}