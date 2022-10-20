using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement : MonoBehaviour
{
    //MainMenu = 0
    //Aquarium = 1
    //Fishing Wondow = 2
    private void Update()
    {
        
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
    }

    public void LoadAquarium()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public void LoadFishing()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }

}
