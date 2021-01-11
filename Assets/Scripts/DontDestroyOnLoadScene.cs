﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    private GameObject[] objects;

    public static DontDestroyOnLoadScene instance;

    private void Awake()
    {
        instance = this;

        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }
    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }
}
