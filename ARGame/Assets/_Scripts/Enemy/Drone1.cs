using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone1 : Enemy
{

    Rigidbody rbody;

    public GameObject bullet;
    public GameObject deathVFX;
    public GameObject explodeVFX;
    public Transform randomCenter;
    public float fireRate = 50f;
    public float rotateSpeed = 0.1f;
    public float moveSpeed = 5f;

    private float moveDist = 1f;
    private float fireCooldown = 0f;

    private GameObject player;

    private Vector3 randomPos;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        randomPos = GetRandomPos(randomCenter);
    }
	
	// Update is called once per frame
	void Update () {
        if (isDead)
            return;
        if (player != null)
        {
            Vector3 relativePos = player.transform.position - transform.position;
            Quaternion lookat = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookat, rotateSpeed * Time.deltaTime * GlobalTimeScaler.scale);
        }
        FireControl();
        Move();
        //Debug.Log("FireCooldown = " + fireCooldown);
    }

    void FireControl()
    {
        if (fireCooldown <= 0f)
        {
            //shoot
            Instantiate(bullet, transform.position, transform.rotation);
            fireCooldown = fireRate;
        }
        if(GlobalTimeScaler.scale != 0f)
            fireCooldown -= Time.deltaTime;
    }

    public override void Death()
    {
        isDead = true;
        if (deathVFX != null)
            Instantiate<GameObject>(deathVFX, transform);
        gameObject.GetComponent<Collider>().isTrigger = false;
        rbody.useGravity = true;
        rbody.velocity += new Vector3(0,-1,0) * moveSpeed * 0.02f;
        Destroy(gameObject,2f);
    }

    public void OnDestroy()
    {
        enemyNum--;
        if (GlobalTimeScaler.scale == 0f)
            return;
        if (explodeVFX != null)
            Instantiate<GameObject>(explodeVFX).transform.position = transform.position;
    }

    public void Move()
    {
        float dist =  Vector3.Distance(transform.position, randomPos);

        if(dist <= moveDist)
        {
            while(dist < moveDist)
            {
                randomPos = GetRandomPos(randomCenter);
                dist = Vector3.Distance(transform.position, randomPos);
            }
        }
        else
        {
            Vector3 direction = randomPos - transform.position;
            rbody.velocity = direction.normalized * 0.02f * moveSpeed * Mathf.Clamp(dist / 3, 0.25f, 1f) * GlobalTimeScaler.scale;
        }
    }

    private Vector3 GetRandomPos(Transform center)
    {
        Vector3 pos = Random.insideUnitSphere * 5;
        pos += center.position;

        return pos;
    }
}
