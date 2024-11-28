using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspell : MonoBehaviour
{
    public GameObject Spell;
    public Transform player;
    public float Force = 2.0f;
    public float coolDown = 2.0f;
    private EnemyHealth enemyHealth;
    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        StartCoroutine(ShootPlayer());
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    IEnumerator ShootPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(coolDown);

            if (player != null)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
                GameObject spell = Instantiate(Spell, transform.position, Quaternion.identity);
                Vector2 myPos = transform.position;
                Vector2 targetPos = player.position;
                Vector2 direction = (targetPos - myPos).normalized;
                spell.GetComponent<Rigidbody2D>().velocity = direction * Force;
                float damagedPlayer = enemyHealth.dame;
                spell.GetComponent<EnemySpellDame>().dame = damagedPlayer;
            }
        }
    }
    public void Setplayer(Transform playerTransform)
    {
        player = playerTransform;

    }
}

