using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    #region Health_variables
    public float maxHealth;
    float currHealth;
    public Slider HPSlider;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        HPSlider.value = currHealth / maxHealth;
    }


    #region Health_functions

    // Take damage based on value param passed in by caller
    public void TakeDamage(float value) {

        // Decrement health
        currHealth -= value;

        // change UI
        HPSlider.value = currHealth / maxHealth;

        // check if dead
        if (currHealth <= 0) {
            // Die
            Die();
        }
    }

    // destroys player object and triggers end scene stuff
    private void Die() {

        // Destroy this object
        Destroy(this.gameObject);
        // trigger anything to end the game, find GameManager and lose game
        // GameObject gm = GameObject.FindWithTag("GameController");
        // gm.GetComponent<GameManager>().LoseGame();
    }

    #endregion

}
