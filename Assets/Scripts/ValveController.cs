using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ValveController : MonoBehaviour {

    public bool open = false;
    public Vector3 rotation;
    public float moveSpeed;
    public Transform movePipe;
    public Transform inPosition, outPosition;
    public bool moving = false;
    bool initYet = false;
    public TextMeshPro text;

    public void Awake() {

        open = !open;
        Toggle();
        initYet = true;
    }



    public void Toggle() {
       
        if (moving) return;
        
        moving = true;
        if (!open) {
            text.text = "Open";
            open = !open;
            StartCoroutine(MoveToSpot(outPosition, -1));
        } else {
            text.text = "Closed";
            open = !open;
            StartCoroutine(MoveToSpot(inPosition, 1));
        }

        if (initYet)GaugeMaster.instance.UpdateGauges();


    }


    public IEnumerator MoveToSpot(Transform t, int direction) {

      

        moving = true;

        while (movePipe.position != t.position) {
            movePipe.position = Vector3.MoveTowards(movePipe.position, t.position, moveSpeed * Time.deltaTime);
            transform.transform.Rotate(rotation * Time.deltaTime * direction);
            yield return null;
        }

        moving = false;
        
        

    }

    

}
