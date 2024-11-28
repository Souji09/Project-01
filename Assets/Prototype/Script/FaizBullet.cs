using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaizBullet : MonoBehaviour
{
    private float dame;
    public float maxDistance = 15f;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
            dame = (PlayerStat.playerStats.DPS / 2);
        }

    }
    private void Update()
    {
        {
            if (playerTransform != null)
            {
                float distance = Vector2.Distance(transform.position, playerTransform.position);
                if (distance > maxDistance)
                {
                    Destroy(gameObject);
                }

            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            if (other.tag != "Player")
            {
                EnemyHealth E = other.GetComponent<EnemyHealth>();
                SlimeMovementt S = other.GetComponent<SlimeMovementt>();
                Boss_Slime Boss = other.GetComponent<Boss_Slime>();
                if (E != null)
                {
                    E.changeHealth(-dame);
                    
                    

                }
                else if (S != null)
                {
                    S.changeHealth(-dame);
                    
                    
                }
                else if (Boss != null)
                {
                    Boss.changeHealth(-dame);
                    
                    
                }
                
            }
        }

    }

}
