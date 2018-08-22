using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMeter : MonoBehaviour {
    public Text healthText;
    public Image meter;

    public void UpdateHealth(float percent)
    {
        healthText.text = (int)(percent * 100f) + "%";
        meter.fillAmount = percent;
    }
}
