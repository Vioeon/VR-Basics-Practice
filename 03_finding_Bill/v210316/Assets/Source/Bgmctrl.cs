using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgmctrl : MonoBehaviour
{
    public AudioClip BGM;
    AudioSource audioSource;


    public void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();

    }

    public void bgmvolume(float b) // BGM의 Volume을 조절
    {
        audioSource.volume = b;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
