using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Cube,
    Cylinder,
    Prism,
    Pedestal
}

public class PickableObject : MonoBehaviour
{
    public ObjectType objectType;
}
