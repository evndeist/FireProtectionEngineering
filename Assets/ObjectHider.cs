using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHider : MonoBehaviour
{


    GameObject[] toHide;
    public string t;
    public bool showing =  true;

    // Start is called before the first frame update
    void Start()
    {
        toHide = GameObject.FindGameObjectsWithTag(t);
    }


    public void ToggleObjects() {

        showing = !showing;


        foreach(GameObject g in toHide) {
            g.SetActive(showing);
        }



    }







}
