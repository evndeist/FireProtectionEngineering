using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : ControllerBase {

    private float mouseXInput, mouseYInput;
    [SerializeField] private float mouseXSpeed = 60, mouseYSpeed = -60, walkSpeed = 5f, bulletForce = 300f, jumpSpeed = 8f;
    [SerializeField] private GameObject cam;
    [SerializeField] private LayerMask layerMask;
   
    private Rigidbody rigidBody;
    private Vector3 velocity;


    // Start is called before the first frame update
    void Start() {
        
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

        if (!canMove) return;

        //print("Raw: " + Input.GetAxisRaw("Horizontal") + " Normal: " + Input.GetAxis("Horizontal"));

        mouseXInput = Input.GetAxis("Mouse X");
        mouseYInput = Input.GetAxis("Mouse Y");

        transform.Rotate(0, mouseXInput * Time.deltaTime * mouseXSpeed * SENSITIVITY, 0);
        cam.transform.Rotate(mouseYInput * Time.deltaTime * mouseYSpeed * SENSITIVITY, 0, 0);

        

        velocity = cam.transform.forward * Input.GetAxis("Vertical") +
                   cam.transform.right * Input.GetAxis("Horizontal");
        velocity.y = 0;
        if (Input.GetKey(KeyCode.LeftShift)) {
            velocity = velocity * walkSpeed * sprintMultiplier;
        } else {
            velocity = velocity * walkSpeed;
        }
        velocity.y = rigidBody.velocity.y;




        rigidBody.velocity = velocity;





    }


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Death") {
            transform.position = new Vector3(0, 10, 0);

        }
    }



}