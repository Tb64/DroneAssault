using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject enemies;
    public Transform spawn;
    public float size;

    public Transform stage;

    public float speedStart;
    public float speedDelta;
    public float speedCap;

    public float fireStart;
    public float fireDeta;
    public float fireMin;

    private float currentSpeed;
    private float currentFire;

    private int maxEnemies = 1;
	// Use this for initialization
	void Start () {
        currentSpeed = speedStart;
        currentFire = fireStart;

    }
	
	// Update is called once per frame
	void Update () {
        CheckEnemyNum();

    }

    private void SpawnEnemy()
    {
        float nextFire = currentFire - fireDeta;
        if (nextFire <= fireMin)
            nextFire = fireMin;
        float nextSpeed = currentSpeed + speedDelta;
        if (nextSpeed >= speedCap)
            nextSpeed = speedCap;
        Drone1 drone = enemies.GetComponent<Drone1>();
        drone.fireRate = Random.Range(nextFire, currentFire);
        drone.moveSpeed = Random.Range(speedStart, nextSpeed);
        drone.health = Random.Range(1, 5);
        drone.randomCenter = stage;

        currentFire = nextFire;
        currentSpeed = nextSpeed;

        Instantiate<GameObject>(enemies,transform).transform.position = spawn.position + (Random.insideUnitSphere * size);
    }

    private void CheckEnemyNum()
    {
        if(Enemy.enemyNum == 0)
        {
            for (int num = 0; num < maxEnemies; num++)
            {
                SpawnEnemy();
            }
            maxEnemies++;
        }
    }
}
