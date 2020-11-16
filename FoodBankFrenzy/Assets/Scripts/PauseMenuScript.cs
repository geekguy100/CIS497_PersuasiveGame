/*
Name: Chandler Wesoloski
Script: Pause Menu Script
Description: Sets the Pause menu to the Screen and the Button Functionality
Date: October 28, 2020
*/

using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    //Variables
    public GameObject PauseMenuUI;
    public static bool GameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        //Checks if the P key is pressed
        if (Input.GetKeyDown(KeyCode.P) && !GameManager.Instance.GameOver)
        {
            //If the game is paused then it will unpause the game
            if (GameIsPaused)
            {
                Resume();
            }
            //if it is not paused then it will pause the game
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        //Sets the UI back to not being active, and sets the timescale back to default
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void BackToMainMenu()
    {
        //Sets the timescale back to default and goes back to the main menu Scene
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameManager.Instance.LoadLevel(1);
    }

    private void Pause()
    {
        //Sets the Pause menu active so it can be shown on the screen, and sets the timescale to 0 and sets GameIsPaused to true
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
