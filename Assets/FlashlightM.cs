using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FlashlightM : MonoBehaviour
{
    private AudioSource _AudioSource;
    public AudioClip _clipw;

    private void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            _AudioSource.PlayOneShot(_clipw);
        }
    }
}
