using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : MonoBehaviour
{
    //Detects when the Waterball hits something
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
            enemy.TakeDamage(this.GetComponentInParent<PlayerMovement>().damage);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Fireball")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Platform")
        {
            Destroy(this.gameObject);
        }
    }
}
