using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Fishing/Score", order = 8)]
public class FishingScore : ScriptableObject
{
    public int fishingScore;
    public bool times2;
    public bool times4;
    public bool times6;
    public bool times8;
    public bool times10;
}
