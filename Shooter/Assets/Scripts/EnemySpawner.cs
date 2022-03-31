using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Transform> spawnPoints = new List<Transform>();
    public PlayerMovement player;
    public List<GameObject> instantiatedEnemies;
    public int spawnTime;
    
    public int maxEnemyCount;
    private int enemyCount;

    // ***
    //private Coroutine spawnCoroutine;

    private void Awake()
    {
        instantiatedEnemies = new List<GameObject>();
        enemyCount = 0;
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnCoroutine(spawnTime));
        // *** 
        //spawnCoroutine = StartCoroutine(SpawnCoroutine(spawnTime));
    }

    // Update is called once per frame
    private void Update()
    {
        // *** this way of stopping the coroutine is not efficient as it requires enemyCount check once every frame
        //if (enemyCount >= maxEnemyCount)
        //{
        //    // we stop coroutine when number of spawned enemies reaches maxEnemyCount
        //    StopCoroutine(spawnCoroutine);
        //}
    }

    public IEnumerator SpawnCoroutine(int spawnTime)
    {
        System.Random randomIndex = new System.Random();

        while (true)
        {
            int index = randomIndex.Next(0, spawnPoints.Count);
            Vector3 spawnPosition = spawnPoints[index].position;

            GameObject instantiatedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            // instead of setting the Player field to instantiated enemy here
            // it can be done in the Enemy script, in Awake by finding the Player via tag
            // Enemy enemyScript = instantiatedEnemy.GetComponent<Enemy>();
            // enemyScript.player = player.gameObject;
            instantiatedEnemies.Add(instantiatedEnemy);

            enemyCount++;
            if (enemyCount >= maxEnemyCount)
            {
                // we stop coroutine when number of spawned enemies reaches maxEnemyCount
                yield break;
            }

            yield return new WaitForSecondsRealtime(spawnTime);

        }
    }

}
