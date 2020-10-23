using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{

    public LayerMask layerMask;
    public float interactDistance = 10f;
    public InteractionPrompt prompt;
    RaycastHit hit;
    public InAppMenu appMenu;

    private void Awake() {
        prompt.gameObject.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        if (InAppMenu.paused) {
            if (prompt.gameObject.activeInHierarchy) prompt.gameObject.SetActive(false);
        } else {

            Debug.DrawRay(transform.position, transform.forward * interactDistance);
            if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, layerMask, QueryTriggerInteraction.Collide)) {
                InteractionPoint i = hit.collider.gameObject.GetComponent<InteractionPoint>();
                string promptstring = i.GetInteractionName();
                if (promptstring != "") {
                    if (!prompt.gameObject.activeInHierarchy) prompt.gameObject.SetActive(true);
                    prompt.Set(promptstring);
                } else {
                    prompt.gameObject.SetActive(false);
                    return;
                }

                if (Input.GetKeyDown(KeyCode.E)) {
                    i.PerformInteraction();
                }
            } else {
                if (prompt.gameObject.activeInHierarchy) prompt.gameObject.SetActive(false);
                return;
            }
        }


    }
}
