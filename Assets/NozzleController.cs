using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NozzleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem waterParticleSystem;


    public void SetParticles(bool on) {
        StopAllCoroutines();
        waterParticleSystem.gameObject.SetActive(on);
    }

    public void OnThenWaitTillZero(GaugeController g) {
        StopAllCoroutines();
        StartCoroutine(OnThenWaitTillZeroIenum(g));
    }


    IEnumerator OnThenWaitTillZeroIenum(GaugeController g) {

        waterParticleSystem.gameObject.SetActive(true);

        while (g.dial.transform.localEulerAngles.y > g.ymin) {
            yield return null;
        }

        waterParticleSystem.gameObject.SetActive(false);


    }


}
