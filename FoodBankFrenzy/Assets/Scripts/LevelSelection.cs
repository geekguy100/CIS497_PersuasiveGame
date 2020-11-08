using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        GameManager.Instance.LoadLevel(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
