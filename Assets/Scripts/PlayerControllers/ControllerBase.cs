using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBase : MonoBehaviour
{
    public static float SENSITIVITY = 1;
    public float sprintMultiplier = 2f;
    protected bool canMove;
    // Start is called before the first frame update
    void Start() {
        Resume();
    }

    public void Pause() {

        canMove = false;

    }

    public void Resume() {

        canMove = true;

    }
}
