using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAppMenu : MonoBehaviour
{


    public static bool paused = false;
    public ControllerBase flyingController, groundController, currentController;

    
    public GameObject innAppMenu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        innAppMenu.SetActive(false);
        Cursor.visible = false;
        SetFlying();
        currentController.Resume();
    }


    

    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Q)) {
          
            if (paused) {
                currentController.Resume();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                innAppMenu.SetActive(false);
            } else {
                currentController.Pause();
                Cursor.lockState = CursorLockMode.None;
                innAppMenu.SetActive(true);
                Cursor.visible = true;
            }

            paused = !paused;


        }

    }


    bool flying = true;

    public void SetFlying() {
        if (currentController) currentController.Resume();
        groundController.gameObject.SetActive(false);
        flyingController.gameObject.SetActive(true);

        currentController = flyingController;
        currentController.Pause();
        flying = true;
    }




    public void SetGround() {
        if (currentController) currentController.Resume();
        flyingController.gameObject.SetActive(false);
        groundController.gameObject.SetActive(true);

        currentController = groundController;
        currentController.Pause();
        flying = false;
    }


    public void ToggleFlying() {
        if (flying) SetGround();
        else SetFlying();
    }




}
