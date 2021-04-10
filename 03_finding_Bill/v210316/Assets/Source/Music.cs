using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip audioBill;
    public AudioClip audioKarl;
    public AudioClip audioMike;
    public AudioClip audioHouseBig;
    public AudioClip audioHousePart;
    public AudioClip audioTree;
    public AudioClip audioCar;
    AudioSource audioSource;


    public void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
        
    }

    public void PlaySound(string find)
    {
        switch (find)
        {
            case "Bill":
                audioSource.clip = audioBill;
                audioSource.Play();
                break;

            case "Karl":
                audioSource.clip = audioKarl;
                audioSource.Play();
                break;

            case "Mike":
                audioSource.clip = audioMike;
                audioSource.Play();
                break;

            case "House Big":
                audioSource.clip = audioHouseBig;
                audioSource.Play();
                break;

            case "House Part":
                audioSource.clip = audioHousePart;
                audioSource.Play();
                break;

            case "Tree":
                audioSource.clip = audioTree;
                audioSource.Play();
                break;

            case "FreeCar":
                audioSource.clip = audioCar;
                audioSource.Play();
                break;
            
            default:
                audioSource.Stop();
                break;
        }
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
