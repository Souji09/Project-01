using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeMovementt :  MonoBehaviour
{

    public GameObject healthbar;
    public Slider HealthBarSlider; 

    public float maxhealth;
    public float currenthealth;
    public float speed = 3.0f;
    public float dame = 2.0f;

    public GameObject Ingot;

    private GameObject player;

    bool IsDamed;

    private Coroutine dameCoroutine;
    Rigidbody rb;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currenthealth = maxhealth;
        healthbar.SetActive(true);
        IsDamed = false ;
        
    }
    private void FixedUpdate()
    {
        if(player != null)
        {
            FindPlayer();
        }
        UpdateStatsBasedOnFloor();
    }

    public void changeHealth(float dame)
    {
        currenthealth = Mathf.Clamp(currenthealth + dame, 0, maxhealth);
        HealthBarSlider.value = CalHealth();
        checkdead();

    }

    private float CalHealth()
    {
        return currenthealth / maxhealth;
    }
    private void checkdead()
    {
        if (currenthealth <= 0) 
        {
            OnDestroy();
            healthbar.SetActive(false);
            int rate = Random.Range(1, 11);
            if (rate >= 7)
            {
                Instantiate(Ingot, transform.position, Quaternion.identity);
            }
            PlayerStat.playerStats.EXP += 1;
            PlayerStat.playerStats.UpdateEXp();
            SpawnMonsters.SpMonster.KillMonster();
            PlayerStat.playerStats.SlimeKilled += 1;
            
            
        } 
            

    }
    private void OnDestroy()
    {
        Destroy(gameObject);
    }
    void FindPlayer()
    {     
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Player")
            {
                if (dameCoroutine == null)
                {
                    dameCoroutine = StartCoroutine(damePlayer());
                }
            }
        }
    }
    void UpdateStatsBasedOnFloor()
    {      
        
            maxhealth = 30 + (Floor.instance.CurrentFloor * 5); // Thay đổi các giá trị này tùy thuộc vào yêu cầu của bạn
            dame = 5 + (Floor.instance.CurrentFloor * 0.5f);
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.tag == "Player")
        {
            StopCoroutine(dameCoroutine);
            IsDamed = false;
            dameCoroutine = null;
        }
    }

    IEnumerator damePlayer()
    {
        
        while (true)
        {
            while (IsDamed == false)
            {
                PlayerStat.playerStats.changeHealth(-5);
                IsDamed = true;
                yield return new WaitForSeconds(1f);
                IsDamed = false;
            }
            yield return null;
            
        }
       

    }




}
