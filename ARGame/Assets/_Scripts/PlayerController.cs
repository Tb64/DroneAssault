using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Actor
{
    public Bullet bullet;

    public GameObject gameOver;

    public HealthMeter hpMeter;

    public Text scoreText;

    private int maxShots = 10;
    private int currentshots = 0;
    private float fireCooldown = 1f;

    private float nextShot = 0f;

    private int startingHealth;
	// Use this for initialization
	void Start () {
        score = 0;
        GlobalTimeScaler.ResetTime();
        health = 25;
        startingHealth = health;
        hpMeter.UpdateHealth(1);
    }
	
	// Update is called once per frame
	void Update () {
        FireControl();
        ScoreUpdate();
    }

    

    void ScoreUpdate()
    {
        if (scoreText == null)
            return;

        int scoreTotal = score - (startingHealth - health);
        scoreText.text = scoreTotal + " SCORE";
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        hpMeter.UpdateHealth(Mathf.Clamp01((float)health / (float)startingHealth));
    }

    private void GameOver()
    {
        if (gameOver == null)
            return;
        nextShot = float.MaxValue;
        GlobalTimeScaler.StopTime();
        gameOver.SetActive(true);
    }

    public override void Death()
    {
        Debug.Log("died");
        GameOver();
    }

    private void FireControl()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            Fire();
    }

    public void Fire()
    {
        if(nextShot > Time.time)
        {
            //ARDebug.Log("cooling down " + nextShot);
            return;
        }
        if(currentshots >= maxShots)
        {
            ARDebug.Log("reloading " + currentshots + "/" + maxShots);
            currentshots = 0;
            nextShot = Time.time + fireCooldown;
            return;
        }
        Instantiate(bullet, transform.position, transform.rotation);
        currentshots++;
    }

    public void ResetCam()
    {
        Camera.current.transform.localPosition = new Vector3(0f,0f,0f);
    }
}
