using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpellDame : MonoBehaviour
{
    public float dame;

    // Start is called before the first frame update

    private void Start()
    {
        EnemyHealth dame = GetComponent<EnemyHealth>();
    }
    private void Update()
    {
        Destroy(gameObject,2f);
       
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        
        {
            if (other != null)
            {

                if (other.tag == "Player")
                {
                    PlayerStat.playerStats.changeHealth(-dame);
                    Destroy(gameObject);
                }
                Destroy(gameObject);
            }
            

        }


    }

}

