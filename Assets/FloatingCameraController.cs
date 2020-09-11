using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCameraController : ControllerBase
{

    public float maxDistanceFromCenter;
    public Transform center;

    public float RotateSpeed = 180f;
    public float MoveSpeed = 5f;
    public float rotXRange = 75f;
   


    public float rotX, rotY;


    private void Awake() {
        rotX = transform.eulerAngles.x;
        rotY = transform.eulerAngles.y;
    }

    // Update is called once per frame
    Vector3 newPosition;

    void Update()
    {

        if (!canMove) return;

        
        if (Input.GetKey(KeyCode.LeftShift)) {
            newPosition = ((Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime * sprintMultiplier) * transform.right)
                + transform.forward * Input.GetAxis("Vertical") * MoveSpeed * sprintMultiplier * Time.deltaTime;
            newPosition += new Vector3(0, Input.GetAxis("UPDOWN") * MoveSpeed * sprintMultiplier * Time.deltaTime, 0);
        } else {
            newPosition = ((Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime) * transform.right)
                + transform.forward * Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
            newPosition += new Vector3(0, Input.GetAxis("UPDOWN") * MoveSpeed * Time.deltaTime, 0);
        }


        newPosition += transform.position;

        if (Vector3.Distance(newPosition, center.transform.position) > maxDistanceFromCenter) {

        } else {
            transform.position = newPosition;
        }



        rotY += Input.GetAxis("Mouse X") * RotateSpeed * SENSITIVITY * Time.deltaTime;
        rotX += -Input.GetAxis("Mouse Y") * RotateSpeed * SENSITIVITY * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -rotXRange, rotXRange);

        transform.eulerAngles = new Vector3(rotX, rotY, 0);

    }
}
