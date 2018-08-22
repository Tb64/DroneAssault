using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARDebug : MonoBehaviour {

    private static Text ARDebugLog;
    private static List<string> log;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    static public void Log(string input)
    {
        Debug.Log(input);
        GameObject gobj = GameObject.FindGameObjectWithTag("ARDebugLog");
        if (gobj == null)
            return;

        ARDebugLog = gobj.GetComponent<Text>();

        if (ARDebugLog == null)
            return;

        if (log == null)
            log = new List<string>();

        log.Add(Time.time.ToString("000.00") + "| " + input);

        if (log.Count > 20)
            log.RemoveAt(0);

        ARDebugLog.text = "";
        foreach (string line in log)
        {
            ARDebugLog.text = line + "\n" + ARDebugLog.text;
        }
    }
}
