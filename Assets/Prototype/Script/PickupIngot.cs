using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupIngot : MonoBehaviour
{
    
    public enum pickupObject { INGOT, EXP };

    public pickupObject currentObject;

    public int pickupQuantity;

    public GameObject player;
    public float speed = 2.0f;

    private void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, player.transform.position) < 0.1f)
            {
                PlayerStat.playerStats.AddCurrency(this);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    if(collision != null)
        {
            if(collision.tag == "Player")
            {
                player = collision.gameObject;
            }
        }
    }


}
