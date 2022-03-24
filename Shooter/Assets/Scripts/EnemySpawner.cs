using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private List<GameObject> spawnedEnemies;
    public GameObject enemyPrefab;
    private List<Vector3> spawnPoints;
    public int numberOfEnemies;

    public GameObject SpawnEnemy()
    {
        int rnd = Random.Range(0, spawnPoints.Count - 1);
        return Instantiate(enemyPrefab, spawnPoints[rnd], enemyPrefab.transform.rotation);
    }

    private void Awake()
    {
        spawnedEnemies = new List<GameObject>();
        spawnPoints = new List<Vector3>();
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // very ugly randomization of positions, i know :(
            int rndZ = Random.Range(-23, -60);
            int rndX = Random.Range(-50, -57);
            spawnPoints.Add(new Vector3(rndX, 0.01f, rndZ));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<numberOfEnemies; i++)
        {
            GameObject enemy = SpawnEnemy();
            enemy.gameObject.GetComponent<Enemy>().player = GameObject.FindGameObjectWithTag("Player");
            spawnedEnemies.Add(enemy);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
