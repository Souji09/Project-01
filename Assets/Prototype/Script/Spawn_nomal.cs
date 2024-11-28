using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
public class Spawn_nomal : MonoBehaviour
{
    // Start is called before the first frame update

    
    public GameObject[] enemy;
    private float spawnRange = 4f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(SpawnWaves());
            
        }       

    }
    IEnumerator SpawnWaves()
    {

        int rate = Random.Range(5, 7);
        for (int i = 0; i < rate; i++)
        {

            Spawnmonster();
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }
    void Spawnmonster()
    {
        
        Debug.Log("Enter");
        Vector3 VitriSpawn = transform.position + new Vector3(0, 0, 0);
        Vector2 spawnCenter = transform.position;
        Vector2 randomPosition = new Vector2(
            spawnCenter.x + UnityEngine.Random.Range(-spawnRange, spawnRange),
            spawnCenter.y + UnityEngine.Random.Range(-spawnRange, spawnRange));
        Instantiate(enemy[Random.Range(0, enemy.Length)], randomPosition, quaternion.identity);
        
    }
}
