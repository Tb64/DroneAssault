using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

    public int health;
    public static int score;

    protected bool isDead = false;

    public virtual void TakeDamage(int damage)
    {
        score++;
        health -= damage;
        ARDebug.Log("Damged " + name + " " + health + " (" + damage + ")");
        if (health <= 0)
            Death();
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }
}
