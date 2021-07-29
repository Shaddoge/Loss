using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Pedestal,
    PlateCube,
    PlateCylinder,
    PlatePrism
}

public class PickableObject : MonoBehaviour
{
    public ObjectType objectType;
}
