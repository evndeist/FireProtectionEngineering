using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveInteractionPoint : InteractionPoint {

    public ValveController controller;

    public override string GetInteractionName() {
        
        if (controller.moving) {
            return "";
        }

        if (!controller.open) {
            return "Close Valve";
        } else {
            return "Open Valve";
        }


    }

    public override void PerformInteraction() {

        controller.Toggle();

    }




}
