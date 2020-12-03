using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Sam Ferstein
 * ButtonLink.cs
 * This is the code that lets the buttons transition from the winning and losing screen to the next level/main menu.
 */

public class ButtonLink : MonoBehaviour
{
    [SerializeField] private bool levelLost = false;
    [SerializeField] private bool returnToMenu = false;

    private bool transitioned = false;
    
    void Start()
    {
        //Update the "Next Level" button to say "Go to Title Screen" if the last lvl was just compelted.
        if ((GameManager.Instance.PreviousLevel + 1 > 7) && name == "MainMenuButton")
        {
            GetComponentInChildren<Text>().text = "Return to Title Screen";
        }
    }

    public void BackToMainMenu()
    {
        if (transitioned)
            return;

        transitioned = true;

        if (returnToMenu)
        {
            GameManager.Instance.LoadLevel(1);
            return;
        }

        //Play the level again if lost.
        if (levelLost)
        {
            GameManager.Instance.LoadLevel(GameManager.Instance.PreviousLevel);
            return;
        }

        //Proceed to next lvl if won.
        //Load the menu if the next level is the win scene; the player has finished the final level, so go back to title screen.
        if (GameManager.Instance.PreviousLevel + 1 > 7)
            GameManager.Instance.LoadLevel(0);
        else
            GameManager.Instance.LoadLevel(GameManager.Instance.PreviousLevel + 1, true);
    }
}