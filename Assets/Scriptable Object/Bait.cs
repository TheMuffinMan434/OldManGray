using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Fishing/Bait", order = 2)]
public class Bait : ScriptableObject
{
    public string title;
    public Sprite image;

    public List<Fish> fishes;
}

