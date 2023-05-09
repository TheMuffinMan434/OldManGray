using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    public Vector2 PointerPosition;

    private void Update()
    {
        transform.up = (PointerPosition - (Vector2)transform.position).normalized;
    }
}
