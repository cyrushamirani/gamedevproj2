using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("found player");
            collision.transform.GetComponent<PlayerMovement>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
