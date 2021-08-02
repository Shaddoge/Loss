using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    BlueCube,
    RedCube,
    YellowCube,
    GreenCube,
    PinkCube,
    CyanCube
}

public class PlateTriggerObject : MonoBehaviour
{
    public ObjectType objectType;

}
