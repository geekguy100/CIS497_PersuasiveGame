/*
Name: Chandler Wesoloski
Script: Tutorial Text Script
Description: Changes the Text when the player follows the directions
Date: November 10, 2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTextScript : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;

    public Pickup PickupScript;

    private bool[] tutorialsCompleted  = new bool[] { false, false, false };

    // Start is called before the first frame update
    void Start()
    {
        tutorialText = GetComponent<TextMeshProUGUI>();

        PickupScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Pickup>();

        tutorialText.SetText("Controls:\nLeft Click to pick up a can.");

        for(int i = 0; i < tutorialsCompleted.Length; i++)
        {
            tutorialsCompleted[i] = false;
        }
    }

    private void Update()
    {
        if (PickupScript.objectInHand != null && tutorialsCompleted[0] == false)
        {
            tutorialText.SetText("Controls:\nLeft Click to drop the Can.");
            tutorialsCompleted[0] = true;
        }
        if (PickupScript.objectInHand == null && tutorialsCompleted[0] == true)
        {
            tutorialText.SetText("Controls\nPress Escape to pause the game.");
            tutorialsCompleted[1] = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && tutorialsCompleted[1] == true)
        {
            tutorialText.SetText("Congratulations! You have completed this part of the tutoial!\n All you have to do now is put the cans required into the box!");
            tutorialsCompleted[2] = true;
        }
        if (tutorialsCompleted[2] == true)
        {
            tutorialText.SetText("Congratulations! You have completed this part of the tutoial!\nAll you have to do now is put the cans required into the box!");
        }
    }
}
