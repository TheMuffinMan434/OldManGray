using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GetMousePosition : MonoBehaviour
{
    [SerializeField]
    /*private InputActionReference pointerPosition;*/

    public Rod rod;
    public bool leftClick = false;

    void Update()
    {
        if (!leftClick)
            NotFishing();
       
    }

    public void NotFishing()
    {
        Vector2 pointerInput = GetPointerInput();
        rod.PointerPosition = pointerInput;
    }

    public Vector2 GetPointerInput()
    {
        Vector2 mousePos = Input.mousePosition;
        return mousePos;
    }
}
