using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BaitImage : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public Bait baitList;

    public Sprite imageTarg;
    public Image imageChange;

    private void Update()
    {
        int value = dropdown.value;
        string baitName = baitList.baits[value].name;
        ChangeImage(baitName);
    }

    public void ChangeImage (string name)
    {
        for(int i = 0; i < baitList.baits.Length; i++)
        {
            if (baitList.baits[i].name == name)
                imageTarg = baitList.baits[i].image;
        }
        imageChange.sprite = imageTarg;
    }

}
