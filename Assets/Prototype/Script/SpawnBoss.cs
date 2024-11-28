using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Boss;
    public GameObject Wall;
    private float heightAbovePlayer = 7f;
    private float heightBelowlayer = -1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            Debug.Log("Enter");
            Vector3 VitriSpawnBoss = transform.position + new Vector3(0, heightAbovePlayer, 0);
            Vector3 VitriSpawnWall = transform.position + new Vector3(0, heightBelowlayer, 0);
            Instantiate(Boss, VitriSpawnBoss, Quaternion.identity);
            Instantiate(Wall, VitriSpawnWall, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
