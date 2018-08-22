using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTranslator : MonoBehaviour {

    public GameObject arCamera;
    public GameObject viewCamera;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = viewCamera.transform.localPosition;

    }
	
	// Update is called once per frame
	void Update () {
        viewCamera.transform.localPosition = (arCamera.transform.position * 10f) + offset;
        viewCamera.transform.localRotation = arCamera.transform.rotation;

    }
}
