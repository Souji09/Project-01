using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackPlayer : MonoBehaviour
{
    public float Knock;
    public float Time;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();
            if (player != null)
            {
                Debug.Log("KnockBack");
                Vector2 difference = player.transform.position - transform.position;
                difference = difference.normalized * Knock;
                player.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockBack(player));
            }

        }
        
    }
     private IEnumerator KnockBack(Rigidbody2D player)
    {
        if (player != null)
        {
            yield return new WaitForSeconds(Time);
            player.velocity = Vector2.zero;
        }
    }
}
