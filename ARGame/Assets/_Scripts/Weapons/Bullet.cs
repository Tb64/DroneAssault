using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public string shooterTag;
    public float speed = 10f;
    public int damage;

    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * speed * GlobalTimeScaler.scale;

        Destroy(gameObject, 10f);
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.forward * speed * GlobalTimeScaler.scale;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ignore")
            return;
        if (other.tag == shooterTag)
        {
            
            return;
            //(gameObject);
        }
        if(other.tag == "Player" || other.tag == "Enemy")
            other.GetComponent<Actor>().TakeDamage(damage);
        ARDebug.Log("Bullet: " + name + " hits " + other.name);
        Destroy(gameObject);
    }
}
