using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement : MonoBehaviour
{
    //MainMenu = 0
    //Aquarium = 1
    //Fishing Window = 2
    //New Fishing Window = 3
    public bool isFishing = false;
    public bool isAquarium = true;
    private void Update()
    {
        
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadAquarium()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void LoadFishing()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Additive);  
    }

}
