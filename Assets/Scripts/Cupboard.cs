using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupboard : MonoBehaviour
{
    public bool inTheBoard;
    public GameObject text;
    public GameObject lButton;
    public CharacterControl charCntrl;

    private void Start()
    {
        inTheBoard = false;
        text.SetActive(false);
        lButton.SetActive(false);
        charCntrl.enabled = true;
    }
    public void InTheCupboard()
    {
        inTheBoard = true;
        text.SetActive(true);
        lButton.SetActive(true);
        charCntrl.enabled = false;
    }

    public void OutTheCupboard()
    {
        inTheBoard = false;
        lButton.SetActive(false);
        text.SetActive(false);
        charCntrl.enabled = true;
    }
}
