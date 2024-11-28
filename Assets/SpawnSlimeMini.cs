using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlimeMini : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject Slime;
    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    IEnumerator StartSpawn()
    {
        while(true)
        {
            int rate = Random.Range(-1,1);
            Vector3 VitriSpawnBoss = transform.position + new Vector3(2, rate, 0);
            Vector3 VitriSpawnWall = transform.position + new Vector3(-2, rate, 0);
            Vector3 VitriSpawn = transform.position + new Vector3(rate, -2, 0);
            Instantiate(Slime, VitriSpawnBoss, Quaternion.identity);
            Instantiate(Slime, VitriSpawnWall, Quaternion.identity);
            Instantiate(Slime, VitriSpawn, Quaternion.identity);
            yield return new WaitForSeconds(7);
        }
    }
            
        
}
