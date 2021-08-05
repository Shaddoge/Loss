using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    [SerializeField] private CharacterState part;
    [SerializeField] private List<GameObject> parts = new List<GameObject>();

    private void Start()
    {
        switch (part)
        {
            case CharacterState.LeftArm: GameObject.Instantiate(parts[0], this.transform); break;
            case CharacterState.RightArm: GameObject.Instantiate(parts[1], this.transform); break;
            case CharacterState.Legs: GameObject.Instantiate(parts[2], this.transform); break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character)
        {
            character.AddState(part);
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(this.transform.GetChild(0).gameObject);
            StartCoroutine(Destroy());
        }
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }
}
