using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManager : MonoBehaviour
{

    public const string mainMenu = "MainMenu";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void LoadScene(string scene) {

        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);

    }


    public void GoToMainMenu() {
        LoadScene(mainMenu);
    }


    public void Quit() {
        Application.Quit();
    }
}
