using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    #region Singleton
    //=====Singleton=====
    private static EnemySpawning _instance;

    public static EnemySpawning Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<EnemySpawning>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<EnemySpawning>();
                }
            }
            return _instance;
        }
        private set { _instance = value; }
    }
    #endregion

    public GameObject enemyPrefab;
    public Transform enemyParent;
    public int currentlySpawned;
    public int maxSpawned;
    public List<Transform> spawnLocations = new List<Transform>();

    private void Update()
    {
        CheckSpawned();
    }

    private void CheckSpawned()
    {
        if (currentlySpawned < maxSpawned)
        {
            int index = Random.Range(0, spawnLocations.Count);
            Instantiate(enemyPrefab, spawnLocations[index].position, Quaternion.identity, enemyParent);

            currentlySpawned++;
        }
    }
}
