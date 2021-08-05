using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Preload");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }

    public void LoadCredits()
    {
        Debug.Log("No Credits Yet LMAO");
    }
}
