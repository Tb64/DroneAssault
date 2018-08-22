using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnDestroy : MonoBehaviour {

    public GameObject effect;
    public float time;

    private void OnDestroy()
    {
        if (GlobalTimeScaler.scale == 0f)
            return;
        if (effect == null)
            return;
        effect.transform.position = transform.position;
        GameObject gobj = Instantiate<GameObject>(effect);
        Destroy(gobj, time);
    }
}
