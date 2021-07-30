using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if (isLoaded)
            SceneManager.UnloadSceneAsync(scene, UnloadSceneOptions.None);
        else
        {
            SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

        }
        isLoaded = !isLoaded;
    }
}
