using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private float dame ;
    public float maxDistance = 5f;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player!= null)
        {
            playerTransform = player.transform;
            dame = PlayerStat.playerStats.DPS;
        }

    }
    private void Update()
    {
        {
            if(playerTransform != null )
            {
                float distance = Vector2.Distance(transform.position, playerTransform.position);
                if(distance > maxDistance)
                {
                    Destroy(gameObject);
                }

            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other != null)
        {
            if (other.tag != "Player")
            {
                EnemyHealth E = other.GetComponent<EnemyHealth>();
                SlimeMovementt S = other.GetComponent<SlimeMovementt>();
                Boss_Slime Boss = other.GetComponent<Boss_Slime>();
                if (E != null)
                {
                    E.changeHealth(-dame);
                    Skill.Instance.CheckSkillready(1);
                    Skill.Instance.UpdateSkillUI();
                    Destroy(gameObject, 0.1f);

                }
                else if (S != null)
                {
                    S.changeHealth(-dame);
                    Skill.Instance.CheckSkillready(1);
                    Skill.Instance.UpdateSkillUI();
                    Destroy(gameObject, 0.1f);
                }
                else if (Boss != null)
                {
                    Boss.changeHealth(-dame);
                    Skill.Instance.CheckSkillready(1);
                    Skill.Instance.UpdateSkillUI();
                    Destroy(gameObject,0.1f);
                }
                Destroy(gameObject);
            }
        }
        
    }

}
