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
    private static Character instance = null;
    [SerializeField] private CharacterState state = CharacterState.None;
    public event Action<CharacterState> OnStateAdded = delegate { };
    private void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.DESTROY_PLAYER, DestroyCharacter);
        if (!instance)
            instance = this;
        else
            DestroyCharacter();
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.DESTROY_PLAYER);
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

    public void DestroyCharacter()
    {
        instance = null;
        Destroy(this.gameObject);
    }
}
