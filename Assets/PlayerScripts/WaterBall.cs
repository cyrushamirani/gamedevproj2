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
            // collision.gameObject.damage();
        }
        if (!collision.gameObject.CompareTag("Player")
            && !collision.gameObject.CompareTag("Background"))
        {
            Destroy(this.gameObject);
        }
        
    }
}
