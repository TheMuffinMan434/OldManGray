using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ButtonLocations")]
public class ButtonLocal : ScriptableObject
{
    public List<Vector3> locations;
}
