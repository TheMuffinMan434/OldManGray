using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Fishing/WindowInfo", order = 1)]
public class FishingWindow : ScriptableObject
{
    public int tankNumber;

    public string[] fishes;

    public Bait[] baits;
}
