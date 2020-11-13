/*
 * Chris Smith
 * Food Bank Frenzy
 * Script to load levels from level selection screen.
 */

using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool returnedToMenu = false;

    public void LoadLevel(int level)
    {
        bool loadInterScene = false; //For all playable levels, play intermediary need scene
        if (level > 1)
            loadInterScene = true;

        GameManager.Instance.LoadLevel(level, loadInterScene);
    }

    private void Update()
    {
        //Return to menu.
        if (Input.GetKeyDown(KeyCode.Escape) && !returnedToMenu)
        {
            returnedToMenu = true;
            GameManager.Instance.LoadLevel(0);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
