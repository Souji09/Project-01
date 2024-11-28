using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float maxHealth;
    public float currentHealt;

    public float Armor;

    public float speed { get; set; }

    Vector2 movement;

    public Rigidbody2D rb;

    Animator animator;
    Vector2 lookdirection = new Vector2(1,0);

    float dashspeed = 6f;
    float dashduration = 0.2f;
    float dashcooldown = 0.5f;

    float staminacost = 35.0f;
    bool isDashing;
    bool canDash;
    public GameObject Dasheffect;
    Vector2 move;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        speed = 2f;
        maxHealth = PlayerStat.playerStats.maxhealth;
        Armor = PlayerStat.playerStats.Armor;

        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();

        isDashing = false;
        canDash = true;

       
    }

    // Update is called once per frame
    void Update()
    {
        
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        
        if(PlayerStat.playerStats.currentTheLuc >=  staminacost && !isDashing )
        {
            canDash = true;
        }
        else
        {
            canDash = false;
        }
        if (isDashing)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            Debug.Log("Dashing");
            PlayerStat.playerStats.changeTheLuc(staminacost);
            StartCoroutine(Dash());
        } 
        if(Input.GetKeyDown(KeyCode.R )&& PlayerStat.playerStats.healingPotion >= 1)
        {
            Audio.Instance.PlaySFX("Heal");
            PlayerStat.playerStats.HealingUse();
            PlayerStat.playerStats.healingPotion -= 1;
            PlayerStat.playerStats.UpdatePotion();
        }



       
        move = new Vector2(movement.x,movement.y).normalized;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - rb.position;
        direction.Normalize();
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookdirection = direction;
        }
        

        if (mousePosition.x < rb.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }
     void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        
    }
    void changespeed()
    {
        speed = PlayerStat.playerStats.speed;
    }
    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        
        float originalSpeed = speed;

        PlayerStat.playerStats.Isbatu = true;
        
        Dasheffect.SetActive(true);
        speed = dashspeed;
        
        rb.velocity = movement.normalized * dashspeed;

        yield return new WaitForSeconds(dashduration);


        speed = originalSpeed;

        
        isDashing = false;
        PlayerStat.playerStats.Isbatu = false;
        
        Dasheffect.SetActive(false);
        yield return new WaitForSeconds(dashcooldown);
        
        canDash = true;
    }
    

}
