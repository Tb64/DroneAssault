using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTimeTrigger : MonoBehaviour {

    public bool slowed = false;
    public GameObject overlay;
    public AudioEchoFilter audioFX;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Bullet")
            return;

        if (other.GetComponent<Bullet>().shooterTag != "Enemy")
            return;

        GlobalTimeScaler.SlowTime();
        slowed = true;
        overlay.SetActive(slowed);
        audioFX.enabled = slowed;
        ARDebug.Log("Slowing Time");
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag != "Bullet")
            return;

        StartCoroutine(ResetTimeTrigger());
    }

    IEnumerator ResetTimeTrigger()
    {
        yield return new WaitForSeconds(5);
        if (slowed)
        {
            GlobalTimeScaler.ResetTime();
            slowed = false;
            overlay.SetActive(slowed);
            audioFX.enabled = slowed;
            ARDebug.Log("Reset Time");
        }
    }
}
