using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPoint : MonoBehaviour
{
    
    public virtual string GetInteractionName() {

        return "Interact";

    }

    public virtual void PerformInteraction() {

    }


}
