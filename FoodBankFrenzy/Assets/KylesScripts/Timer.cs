/*****************************************************************************
// File Name :         Timer.cs
// Author :            Kyle Grenier
// Creation Date :     10/28/2020
//
// Brief Description : Basic timer functionality: 
//                     Setting a time and counting down from said time to 0.
*****************************************************************************/
using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    public AudioSource audSrc;
    public AudioClip timeLow;
    [HideInInspector] public float time;
    public bool countingDown { get; private set; }

    private void Awake()
    {
        audSrc = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Starts the countdown of the timer.
    /// This public void function is so I don't have to call StartCoroutine() in the GameManager.
    /// </summary>
    public void BeginCountdown()
    {
        countingDown = true;
    }

    private void Update()
    {
        if (countingDown)
            Countdown();
    }

    /// <summary>
    /// Decrements the timer.
    /// Once it reaches 0, stops counting down.
    /// </summary>
    private void Countdown()
    {
        time -= Time.deltaTime;
        GameManager.Instance.uiManager.UpdateTimerText(time);

        //if (time <= 5)
        //    audSrc.PlayOneShot(timeLow, 0.2f);

        if (time <= 0)
        {
            countingDown = false;
            GameManager.Instance.GameOver = true;
        }
    }
}