using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveController : MonoBehaviour {

    public bool isin = false;
    public Vector3 rotation;
    public float moveSpeed;
    public Transform movePipe;

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

        while (movePipe.position != t.position) {
            movePipe.position = Vector3.MoveTowards(movePipe.position, t.position, moveSpeed * Time.deltaTime);
            transform.transform.Rotate(rotation * Time.deltaTime * direction);
            yield return null;
        }

        moving = false;
        isin = !isin;


    }
}
