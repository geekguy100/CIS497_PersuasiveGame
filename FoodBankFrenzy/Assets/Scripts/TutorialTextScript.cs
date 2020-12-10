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

    private int tutorialNum = 0;

    public bool tutorialComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the Textmesh pro text
        tutorialText = GetComponent<TextMeshProUGUI>();

        //Finds the pickup script from the camera
        PickupScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Pickup>();

        //Sets the Tutuorial Text
        tutorialText.SetText("Controls:\nLeft Click to pick up a can.");
    }

    private void Update()
    {
        if (tutorialNum == 0)
        {
            //If there's an object in the player's hand, complete tutorial 0.
            if (PickupScript.objectInHand)
            {
                tutorialText.SetText("Controls:\nLeft Click to drop the Can.");
                tutorialNum++;
            }
        }
        else if (tutorialNum == 1)
        {
            //If the object is removed from the player's hand (dropped), go to the next tutorial.
            if (!PickupScript.objectInHand)
            {
                tutorialText.SetText("Controls:\nPick up a can and Right Click to reserve a can.");
                tutorialNum++;

            }
        }
        else if (tutorialNum == 2)
        {
            //If a can gets reserve, continue to next tutorial.
            if (PickupScript.itemHeld != null)
            {
                tutorialText.SetText("Controls:\nLeft click on the can in Reserve to Pick it up and use it.");
                tutorialNum++;
            }         
        }
        else if (tutorialNum == 3)
        {
            //If the player picks up and uses the can in the reserve, continue the tutorial.
            if (PickupScript.itemHeld == null)
            {
                tutorialText.SetText("Controls\nPress the \'P\' key to pause the game.");
                tutorialNum++;
            }
        }
        else if (tutorialNum == 4)
        {
            //Once the player pauses the game, complete the tutorial.
            if (Input.GetKeyDown(KeyCode.P))
            {
                tutorialText.SetText("Congratulations! You have completed this part of the tutorial!\nAll you have to do now is put the cans required into the box!\n" +
                "Be aware that dropping a can into the wrong box will result in a 2 second time loss!");
                tutorialComplete = true;
                tutorialNum++;
            }
        }
        //Now that all of the tutorial lvls are complete, wait for the player to complete the level.
        else if (tutorialComplete)
        {
            if(!GameManager.Instance.GameWon && GameManager.Instance.level.score >= GameManager.Instance.level.MaxBoxes)
            {
                GameManager.Instance.GameWon = true;
            }

        }
    }
}