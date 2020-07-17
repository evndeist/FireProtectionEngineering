using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAppMenu : MonoBehaviour
{


    public bool paused = false;
    public FloatingCameraController controller;
    public GameObject innAppMenu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        innAppMenu.SetActive(false);
        Cursor.visible = false;
    }


    

    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Escape)) {
          
            if (paused) {
                controller.Resume();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                innAppMenu.SetActive(false);
            } else {
                controller.Pause();
                Cursor.lockState = CursorLockMode.None;
                innAppMenu.SetActive(true);
                Cursor.visible = true;
            }

            paused = !paused;


        }

    }





}
