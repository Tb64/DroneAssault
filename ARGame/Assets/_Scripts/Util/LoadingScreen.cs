using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour {

    public int nextScene;
    public Image bg;

    private Vector4 color;
 

	// Use this for initialization
	void Start () {
        StartCoroutine(LoadYourAsyncScene());

        if (bg == null)
            return;
        color = bg.color;
        color.w = 0;
        GlobalTimeScaler.StopTime();
    }
	
	// Update is called once per frame
	void Update () {
        if (bg == null)
            return;

        color.w = Mathf.Clamp01(color.w + 0.1f);

        bg.color = color;
        
    }

    IEnumerator LoadYourAsyncScene()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextScene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
