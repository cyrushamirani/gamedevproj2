using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    public float hi;
    public EnemyTypes[] enemyTypes;
    private float[] enemySpawnTimers;

    private void Awake()
    {
        enemySpawnTimers = new float[enemyTypes.Length];
        for (int i = 0; i < enemyTypes.Length; i++)
        {
            enemySpawnTimers[i] = enemyTypes[i].getEnemySpawnTime();
        }
    }

    private void Update()
    {
        for (int i = 0; i < enemyTypes.Length; i++)
        {
            enemySpawnTimers[i] -= Time.deltaTime;
            if (enemySpawnTimers[i] < 0)
            {
                Instantiate(enemyTypes[i].getEnemyFab());
                enemySpawnTimers[i] = enemyTypes[i].getEnemySpawnTime();
            }
        }
    }
}

[System.Serializable]
public struct EnemyTypes
{
    [SerializeField]
    private GameObject EnemyPrefab;
    [SerializeField]
    private float SpawnRate;

    public GameObject getEnemyFab()
    {
        return EnemyPrefab;
    }

    public float getEnemySpawnTime()
    {
        return SpawnRate;
    }
}