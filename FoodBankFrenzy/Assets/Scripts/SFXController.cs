using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public Pickup pickup;
    public AudioSource audioSrc;

    public AudioClip grab;
    public AudioClip drop;
    public AudioClip correct;
    public AudioClip incorrect;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip timeLow;
    public AudioClip boxFinish;
    public AudioClip transition;


    // Start is called before the first frame update
    void Awake()
    {
        pickup = GameObject.FindObjectOfType<Pickup>();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
