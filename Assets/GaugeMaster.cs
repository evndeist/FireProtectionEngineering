using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeMaster : MonoBehaviour
{

    [Header("Valves")]
    public ValveController V1;
    public ValveController V2, V3, V4;

    [Header("Gauges")]
    public GaugeController G1;
    public GaugeController G2, G3, G4;
    public static GaugeMaster instance;

    private void Awake() {
        instance = this;
        G1.SetAmount(100);
        G2.SetAmount(80);
        G3.SetAmount(100);
        G4.SetAmount(80);
    }


    public void UpdateGauges() {

        print("SetGauges " + Time.time.ToString());
       

        if (!V1.open && V2.open && !V3.open && V4.open) {
            G1.SetAmount(100);
            G2.SetAmount(80);
            G3.SetAmount(100);
            G4.SetAmount(80);
        } else if (!V1.open && !V2.open && !V3.open && !V4.open) {
            G1.SetAmount(100);
            G2.SetAmount(80);
            G3.SetAmount(100);
            G4.SetAmount(80);
        } else if (!V1.open && !V2.open && !V3.open && V4.open) {
            G1.SetAmount(100);
            G2.SetAmount(80);
            G3.SetAmount(100);
            G4.SetAmount(80);
        } else if (!V1.open && V2.open && !V3.open && !V4.open) {
            G1.SetAmount(100);
            G2.SetAmount(80);
            G3.SetAmount(100);
            G4.SetAmount(80);
        } else if (V1.open && V2.open && !V3.open && V4.open) {
            G1.SetAmount(70);
            G2.SetAmount(70);
            G3.SetAmount(100);
            G4.SetAmount(80);
        } else if (!V1.open && V2.open && V3.open && V4.open) {
            G1.SetAmount(100);
            G2.SetAmount(80);
            G3.SetAmount(70);
            G4.SetAmount(70);
        } else if (V1.open && V2.open && V3.open && V4.open) {
            G1.SetAmount(40);
            G2.SetAmount(40);
            G3.SetAmount(40);
            G4.SetAmount(40);
        } else if (V1.open && !V2.open && !V3.open && !V4.open) {
            G1.GoToSpotAndZero(100);
            G2.WaitDrop(G1, 80);
            G3.SetAmount(100);
            G4.SetAmount(80);
        } else if (!V1.open && !V2.open && V3.open && !V4.open) {
            G1.SetAmount(100);
            G2.SetAmount(80);
            G3.GoToSpotAndZero(100);
            G4.WaitDrop(G3, 80);
        } else if (V1.open && !V2.open && V3.open && !V4.open) {
            G1.GoToSpotAndZero(100);
            G2.WaitDrop(G1, 80);
            G3.GoToSpotAndZero(100);
            G4.WaitDrop(G3, 80);
        } else if (!V1.open && !V2.open && V3.open && V4.open) {
            G1.SetAmount(100);
            G2.SetAmount(80);
            G3.SetAmount(70);
            G4.SetAmount(70);
        } else if (!V1.open && V2.open && V3.open && !V4.open) {

            G1.SetAmount(100);
            G2.SetAmount(80);
            G3.GoToSpotAndZero(100);
            G4.WaitDrop(G3, 80);
        } else if (V1.open && !V2.open && !V3.open && V4.open) {

            G1.GoToSpotAndZero(100);
            G2.WaitDrop(G1, 80);
            G3.SetAmount(100);
            G4.SetAmount(80);
        } else if (V1.open && !V2.open && V3.open && V4.open) {

            G1.GoToSpotAndZero(100);
            G2.WaitDrop(G1, 80);
            G3.SetAmount(70);
            G4.SetAmount(70);
        } else if (V1.open && V2.open && !V3.open && !V4.open) {

            G1.SetAmount(70);
            G2.SetAmount(70);
            G3.SetAmount(100);
            G4.SetAmount(80);
        } else if (V1.open && V2.open && V3.open && !V4.open) {
            G1.SetAmount(70);
            G2.SetAmount(70);
            G3.GoToSpotAndZero(100);
            G4.WaitDrop(G3, 80);
        }




    }


}
