using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartDisplay : MonoBehaviour
{
    [SerializeField] private Character character;
    [Header("Body Parts")]
    [SerializeField] private GameObject leftArm;
    [SerializeField] private GameObject rightArm;
    [SerializeField] private GameObject legs;
    // Start is called before the first frame update
    private void Awake()
    {
        character.OnStateAdded += UpdateDisplay;
    }

    private void UpdateDisplay(CharacterState state)
    {
        switch (state)
        {
            case CharacterState.LeftArm:
                leftArm.SetActive(true);
                break;
            case CharacterState.RightArm:
                rightArm.SetActive(true);
                break;
            case CharacterState.Legs:
                legs.SetActive(true);
                break;
        }
    }
}
