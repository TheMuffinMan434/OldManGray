using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInRange : MonoBehaviour
{
    public EnemyDetector enemyDetector;
    public Image exclamation;
    void Start()
    {
        exclamation.enabled = false;
    }

    void Update()
    {
        if (enemyDetector.nearby)
            exclamation.enabled = true;
        else
            exclamation.enabled = false;
    }
}
