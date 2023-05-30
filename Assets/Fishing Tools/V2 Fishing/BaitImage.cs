using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BaitImage : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public Bait baitList;
    public string baitName;

    public Sprite imageTarg;
    public Image imageChange;

    private void Update()
    {
        int value = dropdown.value;
        baitName = baitList.baits[value].baitName;
        ChangeImage(baitName);
    }

    public void ChangeImage (string name)
    {
        for(int i = 0; i < baitList.baits.Length; i++)
        {
            if (baitList.baits[i].baitName == name)
                imageTarg = baitList.baits[i].image;
        }
        imageChange.sprite = imageTarg;
    }

}
