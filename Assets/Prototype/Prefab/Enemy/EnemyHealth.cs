using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public GameObject healthbar;
    public Slider HealthBarSlider;
    public float dame = 5;
    private float speed = 0.4f;
    public float maxhealth = 50;
    public float currhealth;

    public GameObject Ingot;
    private GameObject player;

    int wave;
    // Start is called before the first frame update
    void Start()
    {
        currhealth = maxhealth;
        healthbar.SetActive(true);
        player = GameObject.FindGameObjectWithTag("Player");
        UpdateStatEnemy();

    }
    private void FixedUpdate()
    {
        if (player != null)
        {
            FindPlayer();
        }
    }
    public void changeHealth(float dame)
    {
                 currhealth = Mathf.Clamp(currhealth + dame,0,maxhealth );
                 checkDealth();
        HealthBarSlider.value = Cal();

    }
    void checkDealth()
    {
        if (currhealth <= 0)
        {
            OnDestroy();
            healthbar.SetActive(false);
            int rate = Random.Range(1, 11);
            if (rate >= 6)
            {
                Instantiate(Ingot, transform.position, Quaternion.identity);          
            }
            int rateExp = Random.Range(1,3);
            PlayerStat.playerStats.EXP += rateExp;
            PlayerStat.playerStats.UpdateEXp();
            SpawnMonsters.SpMonster.KillMonster();
            PlayerStat.playerStats.MageKilled += 1;
            
        }

    }
    private void UpdateStatEnemy()
    {      
        
            maxhealth = 50 + (Floor.instance.CurrentFloor* 10); // Thay đổi các giá trị này tùy thuộc vào yêu cầu của bạn
            dame = 5 + (Floor.instance.CurrentFloor* 0.5f);
        
    }
private float Cal()
    {
        return (currhealth / maxhealth);
    }
    private void OnDestroy()
    {
        Destroy(gameObject);
    }
    void FindPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
