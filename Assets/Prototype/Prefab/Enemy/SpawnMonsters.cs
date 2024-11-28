using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Unity.Mathematics;
using UnityEngine;

public class SpawnMonsters : MonoBehaviour
{
    public static SpawnMonsters SpMonster;

    [SerializeField] GameObject[] spawnMonster;
    [SerializeField] float spawnRange = 5f;
    [SerializeField] float spawnInterval = 1f;

    public int currentMonstersToSpawn = 0;
    public int totalKilledMonsters = 0;
    public int totalMonstersSpawned = 0; // Track total monsters spawned in the current wave

    void Start()
    {
        SpMonster = this;
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        for (int i = 0; i < 1 + Floor.instance.CurrentFloor; i++)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnMonster();
        }
    }

    void SpawnMonster()
    {
        int monstersToSpawn = 1 + Floor.instance.CurrentFloor;
        totalMonstersSpawned += monstersToSpawn; // Accumulate the total monsters for the wave

        Vector2 spawnCenter = transform.position;
        for (int i = 0; i < monstersToSpawn; i++)
        {
            Vector2 randomPosition = new Vector2(
                spawnCenter.x + UnityEngine.Random.Range(-spawnRange, spawnRange),
                spawnCenter.y + UnityEngine.Random.Range(-spawnRange, spawnRange)
            );
            Instantiate(spawnMonster[UnityEngine.Random.Range(0, spawnMonster.Length)], randomPosition, quaternion.identity);
            currentMonstersToSpawn++;
        }

        Debug.Log($"Spawned {monstersToSpawn} monsters. Total to kill: {currentMonstersToSpawn}");
    }

    public void KillMonster()
    {
        currentMonstersToSpawn--;
        totalKilledMonsters++;
        Debug.Log($"Monster killed. Remaining: {currentMonstersToSpawn}");

        if (ShouldGameFadeOut())
        {
            Debug.Log("Game Done.");
            Floor.instance.FightFloor += 1;
            ChangeMap.GoToNewMap.DisPlayMap();
        }
    }

    bool ShouldGameFadeOut()
    {
        // Check if all spawned monsters for the current wave are killed
        return currentMonstersToSpawn == 0 && totalKilledMonsters >= totalMonstersSpawned;
    }
}
