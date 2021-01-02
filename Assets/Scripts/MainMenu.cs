using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelToLoad;

    public void StartGame()
    {
        SceneManager.LoadScene(LevelToLoad);
    }                       

    public void Settings()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
