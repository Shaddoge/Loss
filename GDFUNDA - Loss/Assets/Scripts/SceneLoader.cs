using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public string scene;
    private bool isLoaded = false;
    // Start is called before the first frame update
    private void Start()
    {
        isLoaded = SceneManager.GetSceneByName(scene).isLoaded;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject[] gameObjects = SceneManager.GetSceneByName(scene).GetRootGameObjects();
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(!isLoaded);
        }
        isLoaded = !isLoaded;
    }
}
