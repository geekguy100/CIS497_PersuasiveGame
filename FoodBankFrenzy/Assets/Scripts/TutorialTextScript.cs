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
    public bool IsTutorialComplete = false;

    //Private Boolean array
    private bool[] tutorialsCompleted  = new bool[] { false, false, false, false, false };

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
        if (PickupScript.objectInHand == null && PickupScript.isHeld == false && tutorialsCompleted[0] == true)
        {
            tutorialText.SetText("Controls:\nPick up a can and Right Click to reserve a can.");
            tutorialsCompleted[1] = true;
        }
        if (PickupScript.isHeld == true && tutorialsCompleted[1] == true)
        {
            tutorialText.SetText("Controls:\nLeft click on the can in Reserve to Pick it up and use it.");
            tutorialsCompleted[2] = true;
        }
        //Checks if there is no object in hand and if the first entry in the array is true, if so it will change the text again
        if (PickupScript.objectInHand == null && tutorialsCompleted[2] == true)
        {
            tutorialText.SetText("Controls\nPress the \'P\' key to pause the game.");
            tutorialsCompleted[3] = true;
        }
        //Checks if the 'P' key is pressed and if the second entry in the array is true, if so it will change the text one final time
        if (Input.GetKeyDown(KeyCode.P) && tutorialsCompleted[3] == true)
        {
            tutorialText.SetText("Congratulations! You have completed this part of the tutorial!\n All you have to do now is put the cans required into the box!\n" +
                "Be aware that dropping a can into the wrong box will result in a 2 second time loss!");
            tutorialsCompleted[4] = true;
        }
        //Checks if the third entry in the array is true and will change the text to the text in the above if statement
        if (tutorialsCompleted[4] == true)
        {
            tutorialText.SetText("Congratulations! You have completed this part of the tutorial!\nAll you have to do now is put the cans required into the box!\n" +
                "Be aware that dropping a can into the wrong box will result in a 2 second time loss!");

            if(IsTutorialComplete == false)
            {
                IsTutorialComplete = true;
            }
        }
    }
}
