using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeController : MonoBehaviour
{

    public Transform dial;
    public float ymin = 60f, yMax = 300f;
    public float maxAmount = 8;
    public float angleMoveSpeed = 90f;



    public void SetAmount(float f) {

        StopAllCoroutines();
        StartCoroutine(GoToPoint(f));

    }

    IEnumerator GoToPoint(float f) {

        float degrees = f / maxAmount;
        float targety = ymin + (yMax - ymin) * degrees;
        
        

        while (dial.transform.localEulerAngles.y != targety) {

            dial.transform.localEulerAngles = new Vector3(0,Mathf.MoveTowards(dial.transform.localEulerAngles.y, targety, angleMoveSpeed * Time.deltaTime),0);
           // print(dial.transform.localEulerAngles.ToString());
            yield return null;
        }

        dial.transform.localEulerAngles = new Vector3(0, targety, 0);




    }

    public void GoToSpotAndZero(float f) {
        StopAllCoroutines();
        float degrees = f / maxAmount;
        float targety = ymin + (yMax - ymin) * degrees;
        dial.transform.localEulerAngles = new Vector3(0, targety, 0);
        StartCoroutine(GoToSpotThenZeroOut(f));
    }


    public IEnumerator GoToSpotThenZeroOut(float f) {

        
        yield return GoToPoint(0);
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
        yield return GoToPoint(0);
    }




}
