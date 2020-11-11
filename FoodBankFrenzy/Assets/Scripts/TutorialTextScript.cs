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
    //Public Variables
    public TextMeshProUGUI tutorialText;
    public Pickup PickupScript;

    //Private Boolean array
    private bool[] tutorialsCompleted  = new bool[] { false, false, false };

    // Start is called before the first frame update
    void Start()
    {
        //Sets the Textmesh pro text
        tutorialText = GetComponent<TextMeshProUGUI>();

        //Finds the pickup script from the camera
        PickupScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Pickup>();

        //Sets the Tutuorial Text
        tutorialText.SetText("Controls:\nLeft Click to pick up a can.");

        //Sets each bool in the array to false
        for(int i = 0; i < tutorialsCompleted.Length; i++)
        {
            tutorialsCompleted[i] = false;
        }
    }

    private void Update()
    {
        //Checks if there is an object in hand and if the 1st entry in the array is false, if so it will change the text
        if (PickupScript.objectInHand != null && tutorialsCompleted[0] == false)
        {
            tutorialText.SetText("Controls:\nLeft Click to drop the Can.");
            tutorialsCompleted[0] = true;
        }
        //Checks if there is no object in hand and if the first entry in the array is true, if so it will change the text again
        if (PickupScript.objectInHand == null && tutorialsCompleted[0] == true)
        {
            tutorialText.SetText("Controls\nPress Escape to pause the game.");
            tutorialsCompleted[1] = true;
        }
        //Checks if the escape key is pressed and if the second entry in the array is true, if so it will change the text one final time
        if (Input.GetKeyDown(KeyCode.Escape) && tutorialsCompleted[1] == true)
        {
            tutorialText.SetText("Congratulations! You have completed this part of the tutoial!\n All you have to do now is put the cans required into the box!");
            tutorialsCompleted[2] = true;
        }
        //Checks if the third entry in the array is true and will change the text to the text in the above if statement
        if (tutorialsCompleted[2] == true)
        {
            tutorialText.SetText("Congratulations! You have completed this part of the tutoial!\nAll you have to do now is put the cans required into the box!");
        }
    }
}
