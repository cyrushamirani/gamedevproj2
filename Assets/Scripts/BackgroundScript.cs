using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D coll) {
		if (isPlayer(coll.gameObject)) {
			PlayerMovement player = coll.gameObject.GetComponent<PlayerMovement>();
			player.Die();
		}
    }

	//Returns whether or not the Game Object is the Player Character
	bool isPlayer(GameObject obj) {
		return obj.CompareTag ("Player");
	}
}
