using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum CharacterState
{
    None = 0,
    LeftArm = 1,
    RightArm = 2,
    Legs = 4,   

    Arms = LeftArm | RightArm
}
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterState state = CharacterState.None;
    public event Action<CharacterState> OnStateAdded = delegate { };
    private void Start()
    {
    }

    public CharacterState GetState()
    {
        return state;
    }

    public void AddState(CharacterState newState)
    {
        state |= newState;
        OnStateAdded(newState);
    }
}
