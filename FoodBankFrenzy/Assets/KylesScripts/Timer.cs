/*****************************************************************************
// File Name :         Timer.cs
// Author :            Kyle Grenier
// Creation Date :     10/28/2020
//
// Brief Description : Basic timer functionality: 
//                     Setting a time and counting down from said time to 0.
*****************************************************************************/
using UnityEngine;

public class Timer : MonoBehaviour
{
    public AudioSource audSrc;
    public AudioClip timeLow;

    private void Awake()
    {
        audSrc = GetComponent<AudioSource>();
    }

    public float time;
    private bool countingDown;

    public void BeginCountdown()
    {
        countingDown = true;
    }

    private void Update()
    {
        if (countingDown)
            Countdown();
        if (time == 5)
        {
            audSrc.PlayOneShot(timeLow);
        }
    }

    private void Countdown()
    {
        time -= Time.deltaTime;
        print("TIMER: " + time);
        if (time <= 0)
            countingDown = false;
    }
}