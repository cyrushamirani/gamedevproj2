using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    #region Movement_variables
    public float movespeed;
    public float jumpforce;
    public float maxspeed;
    public bool feetContact;
    float x_input;
    float y_input;
    #endregion

    #region Attack_variables
    public GameObject waterBall;
    public float projectilespeed;
    public float damage;
    private bool isAttacking;
    private float mouse_x;
    private float mouse_y;
    #endregion

    #region Health_variables
    public float maxHealth;
    float currHealth;
    public Slider HPSlider;
    #endregion 

    #region Physics_components
    Rigidbody2D PlayerRB;
    #endregion 


    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = gameObject.GetComponent<Rigidbody2D>();
        currHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        mouse_x = Input.mousePosition.x;
        mouse_y = Input.mousePosition.y;
        
        
    }

    #region Movement_functions
    //These movement functions deal with moving left and right
    //Also checks for certain buttons that are pressed
    void Move()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(x_input * movespeed, 0);
        movement = movement * Time.deltaTime;
        PlayerRB.AddForce(movement);
        //Checks to see if the player velocity exceeds maxspeed
        if (PlayerRB.velocity.x > maxspeed)
        {
            PlayerRB.velocity = new Vector2(maxspeed, PlayerRB.velocity.y);
        }
        if (PlayerRB.velocity.x < -maxspeed)
        {
            PlayerRB.velocity = new Vector2(-maxspeed, PlayerRB.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && feetContact)
        {
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, 0);
            PlayerRB.AddForce(new Vector2(0, jumpforce));
        }
        if (Input.GetKeyDown(KeyCode.F) && !isAttacking)
        {
            Attack();
        }
    }
    #endregion

    #region Attack_functions
    //Shoots a waterball in the direction the player is facing
    private void Attack()
    {

        GameObject projectile = Instantiate(waterBall, transform.position, transform.rotation);
        Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse_x = mouse.x;
        mouse_y = mouse.y;
        Debug.Log("Position " + transform.position.x + " " + transform.position.y);
        Debug.Log("Mouse " + mouse_x + " " + mouse_y);
        Vector2 projectileDir = new Vector2(mouse_x - PlayerRB.position.x, mouse_y - PlayerRB.position.y);
        projectileDir.Normalize();
        Debug.Log(projectileDir.x);
        Debug.Log(projectileDir.y);
        projectileRB.velocity = projectilespeed * projectileDir;
        
    }

    #endregion

    #region Health_functions

    // Take damage based on value param passed in by caller
    public void TakeDamage(float value) {

        Debug.Log("hi");
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
