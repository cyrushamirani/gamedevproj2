using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    #region Movement_vars
    public float speed;
    public float idle_switch_time;
    float move_idle_time;
    Vector2 curr_dir;
    #endregion Movement_vars

    #region Player_vars
    public Transform player;
    #endregion

    #region Attack_vars
    public float attack_cooldown;
    public float time_between_attack;
    public int attack_barrage_size;
    float time_until_next_attack;
    public GameObject projectile;
    public float fire_speed;
    #endregion

    #region body
    Rigidbody2D EnemyRB;
    #endregion

    #region health_vars
    public float max_health;
    #endregion

    #region Unity_funcs
    private void Awake()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
        time_until_next_attack = attack_cooldown;
        move_idle_time = idle_switch_time;
    }

    private void Update()
    {
        if (player == null)
        {
            IdleBehavior();
        }
        else
        {
            AttackBehavior();
        }
    }
    #endregion Unity_funcs


    #region Behavior_functions
    private void IdleBehavior()
    {
        IdleMovement();
    }

    private void AttackBehavior()
    {
        AttackMovement();
        if (time_until_next_attack <= 0)
        {
            Attack();
            time_until_next_attack = attack_cooldown;
        }
        time_until_next_attack -= Time.deltaTime;
    }
    #endregion

    #region Movement_functions
    private void IdleMovement()
    {
        if (move_idle_time >= idle_switch_time)
        {
            move_idle_time = 0;
            Vector2[] dirs = new Vector2[4] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
            curr_dir = dirs[Random.Range(0, dirs.Length)];
        }
        EnemyRB.velocity = curr_dir * speed;
        move_idle_time += Time.deltaTime;
    }

    private void AttackMovement()
    {
        curr_dir = player.position - transform.position;
        EnemyRB.velocity = curr_dir.normalized * speed;
    }
    #endregion

    #region Attack_functions
    private void Attack()
    {
        GameObject proj = Instantiate(projectile, transform.position, transform.rotation);
        proj.GetComponent<Rigidbody2D>().velocity = (player.position - transform.position).normalized * fire_speed;
    }
    #endregion

    #region Health_functions
    public void TakeDamage(float damage) {
        max_health -= damage;
        if (max_health < 0) {
            Destroy(this.gameObject);
        }
    }
    #endregion
}