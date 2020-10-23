using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GaugeController : MonoBehaviour
{

    public TextMeshPro text;
    public Transform dial;
    public float ymin = 0f, yMax = 360f;
    public float maxAmount = 120;
    public float angleMoveSpeed = 90f;

    float onePerSecondSpeed = 1f;
    
    public void Awake() {
        onePerSecondSpeed = (yMax - ymin) / (maxAmount);
    }


    public void SetAmount(float f) {

        StopAllCoroutines();
        StartCoroutine(GoToPoint(f, angleMoveSpeed));

    }

    IEnumerator GoToPoint(float f, float speed) {

        float degrees = f / maxAmount;
        float targety = ymin + (yMax - ymin) * degrees;

        text.text = f.ToString();

        while (dial.transform.localEulerAngles.y != targety) {


            int value = (int)(((dial.transform.localEulerAngles.y - ymin) / ((yMax - ymin))) * maxAmount);

            text.text = value.ToString();
            dial.transform.localEulerAngles = new Vector3(0,Mathf.MoveTowards(dial.transform.localEulerAngles.y, targety, speed * Time.deltaTime),0);
           // print(dial.transform.localEulerAngles.ToString());
            yield return null;
        }

        dial.transform.localEulerAngles = new Vector3(0, targety, 0);
        text.text = f.ToString();



    }

    public void GoToSpotAndZero(float f) {
        StopAllCoroutines();
        float degrees = f / maxAmount;
        float targety = ymin + (yMax - ymin) * degrees;
        dial.transform.localEulerAngles = new Vector3(0, targety, 0);
        StartCoroutine(GoToSpotThenZeroOut(f));
    }


    public IEnumerator GoToSpotThenZeroOut(float f) {

        
        yield return GoToPoint(0,onePerSecondSpeed);
    }


    public void WaitDrop(GaugeController g, float f) {
        StopAllCoroutines();
        StartCoroutine(WaitTillValueLessThanThenDropToZero(g, f));
    }

    public IEnumerator WaitTillValueLessThanThenDropToZero(GaugeController g, float f) {
        float degrees = f / maxAmount;
        float targety = ymin + (yMax - ymin) * degrees;
        while (g.dial.transform.localEulerAngles.y > targety) {
            yield return null;
        }
        yield return GoToPoint(0,onePerSecondSpeed);
    }




}
