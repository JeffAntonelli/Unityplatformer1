using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level01");
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
