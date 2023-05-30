using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Fishing/Fishes", order = 4)]
public class ScriptableFish : ScriptableObject
{
    public GameObject fish;
    public Baits weakness;
}
