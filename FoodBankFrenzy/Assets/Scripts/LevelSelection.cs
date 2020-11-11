using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        bool loadInterScene = false;
        if (level > 1)
            loadInterScene = true;

        GameManager.Instance.LoadLevel(level, loadInterScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
