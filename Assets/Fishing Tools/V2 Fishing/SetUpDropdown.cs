using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TMP_Dropdown))]
public class SetUpDropdown : MonoBehaviour
{
    public Bait baitList;
    TMP_Dropdown dropdown;
    public List<string> dropdownOptions;

    private void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.ClearOptions();
        foreach (Baits bait in baitList.baits)
        {
            dropdownOptions.Add(bait.baitName);
        }
        dropdown.AddOptions(dropdownOptions);
    }
}
