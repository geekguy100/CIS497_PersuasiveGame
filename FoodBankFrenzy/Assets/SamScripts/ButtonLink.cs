using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLink : MonoBehaviour
{
    public void WebsiteLink()
    {
        Application.OpenURL("https://www.feedingamerica.org/");
    }

    public void BackToMainMenu()
    {
        GameManager.Instance.LoadLevel(0);
    }
}
