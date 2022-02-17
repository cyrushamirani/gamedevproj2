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
            EnemyScript enemy;
            enemy = collision.gameObject.GetComponent<EnemyScript>();
            enemy.TakeDamage(GetComponentInParent<PlayerMovement>().damage);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Fireball")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
