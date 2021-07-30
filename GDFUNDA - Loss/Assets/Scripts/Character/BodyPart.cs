using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public CharacterState part;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Character>())
            other.GetComponent<Character>().AddState(part);
    }
}
