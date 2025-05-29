using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(string scenePath)
    {
        SceneManager.LoadScene(scenePath);
    }

    public void AddScene(string scenePath)
    {
        SceneManager.LoadScene(scenePath, LoadSceneMode.Additive);
    }

    public void UnloadScene(string scenePath)
    {
        SceneManager.UnloadSceneAsync(scenePath);
    }
}
