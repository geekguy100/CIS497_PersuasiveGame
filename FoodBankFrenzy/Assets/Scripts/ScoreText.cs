/*
Name: Chandler Wesoloski
Script: Score Text Script
Description: Changes the text based on the number of boxes completed
Date: October 21, 2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreText : MonoBehaviour
{
    //Declares Variabeles
    public int score;
    public TextMeshProUGUI textbox;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the variables
        textbox = GetComponent<TextMeshProUGUI>();
        textbox.SetText("Number of Boxes: ");

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Changes the text based on what the score is each frame
        textbox.SetText("Number of Boxes: {0}", score);
    }
}
