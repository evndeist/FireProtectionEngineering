using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SenistivitySetter : MonoBehaviour
{

    public Slider slider;


    private void Awake() {
        if (PlayerPrefs.HasKey("Sensitivity")) {
            slider.value = PlayerPrefs.GetFloat("Sensitivity");
            ControllerBase.SENSITIVITY = PlayerPrefs.GetFloat("Sensitivity");
        } else {
            slider.value = 1;
            PlayerPrefs.SetFloat("Sensitivity", 1);
            ControllerBase.SENSITIVITY = 1;
        }
    }


    public void UpdateSens(float f) {
        slider.value = f;
        PlayerPrefs.SetFloat("Sensitivity", f);
        ControllerBase.SENSITIVITY = f;
    }


}
