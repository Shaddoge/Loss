using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum CharacterState
{
    LeftArm = 0,
    RightArm = 1,
    Legs = 2,   

    Arms = LeftArm | RightArm
}
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterState state;

    public CharacterState GetState()
    {
        return state;
    }

    public void AddState(CharacterState newState)
    {
        state |= newState;
    }
}
