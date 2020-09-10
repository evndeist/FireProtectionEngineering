using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeController : MonoBehaviour
{

    public Transform dial;
    public Vector3 zeroPosition, addMax;
    public float maxAmount = 8;


    public void SetAmount(float f) {
        float degrees = f / maxAmount;
        dial.transform.localEulerAngles = zeroPosition + addMax * degrees;
    }

   
}
