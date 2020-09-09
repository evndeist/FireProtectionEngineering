using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveInteractionPoint : InteractionPoint {

    public ValveController controller;

    public override string GetInteractionName() {
        
        if (controller.moving) {
            return "";
        }

        if (controller.isin) {
            return "Loosen Valve";
        } else {
            return "Tighten Valve";
        }


    }

    public override void PerformInteraction() {

        controller.Toggle();

    }




}
