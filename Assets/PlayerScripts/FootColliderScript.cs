using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootColliderScript : MonoBehaviour
{
    //When we enter collison with another gameObject, check if the object is a floor
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isPlatform(collision.gameObject))
        {
            GetComponentInParent<PlayerMovement>().feetContact = true;
        }
    }

    //Sets feetContact to false when we exit collision with a platform
    void OnCollisionExit2D(Collision2D collision)
    {
        if (isPlatform(collision.gameObject))
        {
            GetComponentInParent<PlayerMovement>().feetContact = false;
        }
    }

    private bool isPlatform(GameObject obj)
    {
        return obj.tag == "Platform";
    }
}
