using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectHider : MonoBehaviour
{


    GameObject[] toHide;
    public string t;
    public bool showing =  true;
    public Image image;
    public Sprite onSprite, offSprite;

    void Awake()
    {
        if (t != "")
            toHide = GameObject.FindGameObjectsWithTag(t);
        else
            toHide = new GameObject[0];
        image.sprite = onSprite;
    }


    public void ToggleObjects() {

        showing = !showing;


        if (showing) {
            image.sprite = onSprite;
        } else {
            image.sprite = offSprite;
        }

        foreach(GameObject g in toHide) {
            g.SetActive(showing);
        }

    }







}
