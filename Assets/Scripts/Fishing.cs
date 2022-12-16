using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fishing : MonoBehaviour
{
    SceneManagement activeScene;
    
    void Update()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 2 && Input.GetKeyDown(KeyCode.Tab))
            TabToClose();
    }


    void TabToClose()
    {
        Debug.Log("closing");
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            activeScene.LoadAquarium();
        }
    }
}
