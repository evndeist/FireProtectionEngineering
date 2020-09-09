using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveController : MonoBehaviour {

    public bool isin = false;
    public float rotateSpeed;
    public float moveSpeed;

    public Transform inPosition, outPosition;

    public bool moving = false;



    public void Toggle() {
        if (moving) return;

        moving = true;
        if (isin) {
            StartCoroutine(MoveToSpot(outPosition, -1));
        } else {
            StartCoroutine(MoveToSpot(inPosition, 1));
        }

    }


    public IEnumerator MoveToSpot(Transform t, int direction) {

        print("start");

        moving = true;

        while (transform.position != t.position) {
            transform.position = Vector3.MoveTowards(transform.position, t.position, moveSpeed * Time.deltaTime);
            transform.Rotate(0, rotateSpeed * direction * Time.deltaTime, 0);
            yield return null;
        }

        moving = false;
        isin = !isin;


    }
}
