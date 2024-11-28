using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rest : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {


            Audio.Instance.PlaySFX("boop");
            PlayerStat.playerStats.healingPotion += 5;            
                
                PlayerStat.playerStats.UpdatePotion();
               Destroy(gameObject);
            
            
        }
    }
}
