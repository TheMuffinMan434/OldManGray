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
    public Scene currentScene;

    private void Start()
    {
        /*LoadMenu();*/
    }
    private void Update()
    {
        CheckActiveScene();
        currentScene = SceneManager.GetActiveScene();
    }

    public void CheckActiveScene()
    {
        if (isFishing)
            if (Input.GetKeyDown(KeyCode.Tab))
                CloseFishing();
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
        isFishing = true;
    }

    public void CloseFishing()
    {
        SceneManager.UnloadSceneAsync(3);
        isFishing = false;
    }

}
