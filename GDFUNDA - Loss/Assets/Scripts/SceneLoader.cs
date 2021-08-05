using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string scene;
    [SerializeField] private bool isLoaded = false;
    // Start is called before the first frame update
    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        //GameObject[] gameObjects = SceneManager.GetSceneByName(scene).GetRootGameObjects();
        //foreach (GameObject gameObject in gameObjects)
        //{
        //    gameObject.SetActive(!isLoaded);
        //}
        //Debug.Log("Loaded");
        //isLoaded = !isLoaded;
    }

    private void OnTriggerExit(Collider other)
    {
        Vector3 direction = (other.transform.position - this.transform.position).normalized;

        if (Vector3.Dot(direction, this.transform.forward) > 0.5f)
        {
            LoadScene();
        }
        else
        {
            UnloadScene();  
        }
    }

    private void LoadScene()
    {
        GameObject[] gameObjects = SceneManager.GetSceneByName(scene).GetRootGameObjects();
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(true);
        }
        Debug.Log("Loaded");
        isLoaded = true;
    }

    private void UnloadScene()
    {
        GameObject[] gameObjects = SceneManager.GetSceneByName(scene).GetRootGameObjects();
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }
        Debug.Log("Unloaded");
        isLoaded = false;
    }
}
