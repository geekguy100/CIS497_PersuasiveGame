/*
 * Chris Smith
 * Food Bank Frenzy
 * Script to load levels from level selection screen.
 */

using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        bool loadInterScene = false; //For all playable levels, play intermediary need scene
        if (level > 1)
            loadInterScene = true;

        GameManager.Instance.LoadLevel(level, loadInterScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
