using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBatch : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject[] copySpawn;
    [SerializeField] private List<GameObject> spawnList;
    private bool onCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < copySpawn.Length; i++)
        {
            copySpawn[i].SetActive(false);
        }
    }

    private void Update()
    {
        if(button.GetComponent<TriggerButton>().isActive && !onCooldown)
        {
            onCooldown = true;
            Spawn();
        }
        else if(!button.GetComponent<TriggerButton>().isActive)
        {
            onCooldown = false;
        }
    }

    void Spawn()
    {
        for (int i = 0; i < spawnList.Count; i++)
        {
            Destroy(spawnList[i]);
        }
        spawnList.Clear();

        for (int i = 0; i < copySpawn.Length; i++)
        {
            GameObject instantiatedObj = GameObject.Instantiate(copySpawn[i], this.transform);
            instantiatedObj.SetActive(true);
            spawnList.Add(instantiatedObj);
        }
    }
}
