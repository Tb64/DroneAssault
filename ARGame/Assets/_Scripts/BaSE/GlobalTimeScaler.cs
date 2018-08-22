using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimeScaler : MonoBehaviour {
    public static float scale = 1f;


    public static void SlowTime()
    {
        scale = 0.2f;
    }

    public static void ResetTime()
    {
        scale = 1f;
    }

    public static void StopTime()
    {
        scale = 0f;
    }
}
