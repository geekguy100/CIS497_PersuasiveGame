using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public Pickup pickup;
    public AudioSource audioSrc;

    public AudioClip correct;
    public AudioClip incorrect;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip boxFinish;
    public AudioClip transition;


    // Start is called before the first frame update
    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
