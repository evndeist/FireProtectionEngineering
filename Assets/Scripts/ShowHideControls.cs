using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ShowHideControls : MonoBehaviour
{

    public bool showing = true;
    public Animator panelAnim;

    public void ToggleArrow() {


        if (showing) {
            panelAnim.SetBool("PanelUp", false);
        } else {
            panelAnim.SetBool("PanelUp", true);
        }

        showing = !showing;
       
        
    }

}
