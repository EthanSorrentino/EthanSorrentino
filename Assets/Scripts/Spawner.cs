using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Spawner : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    private float startDelay = 1.5f;
    public float spawnInterval = 1.5f;
    int[] EnemyPosition = { 0, 10, -10 };
    private float spawnZ = 20f;
    public float Score = 0f;
    public float WaveIncrease;
    public float speed = 30f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemyRandom", startDelay, spawnInterval);
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        if (WaveIncrease > 15f)
        {
            speed += 5;
            InvokeRepeating("SpawnEnemyRandom", startDelay, spawnInterval);
            WaveIncrease = 0f;
        }
    }

    void SpawnEnemyRandom()
    {
        Score += 1;
        Debug.Log("Wave Number = " + Score);
        WaveIncrease += 1;
        int randomMethod = UnityEngine.Random.Range(0, 4);

        if (randomMethod == 0)
        {
            SpawnEnemyTop();
        }
        if (randomMethod == 1)
        {
            SpawnEnemyBottom();
        }
        if(randomMethod == 2)
        {
            SpawnEnemyLeft();
        }
        if(randomMethod == 3) 
        {
            SpawnEnemyRight();
        }
        WaveIncrease += 1;
    }
    void SpawnEnemyTop()
    {

        int enemyIndex = UnityEngine.Random.Range(0, EnemyPrefabs.Length);
        int PositionValue = EnemyPosition[UnityEngine.Random.Range(0, EnemyPosition.Length)];
        Vector3 spawnPos = new Vector3(PositionValue, 1, spawnZ);
        Instantiate(EnemyPrefabs[enemyIndex], spawnPos, EnemyPrefabs[enemyIndex].transform.rotation);
        transform.Translate(Vector3.back * Time.deltaTime * speed);

    }
    void SpawnEnemyBottom()
    {

        int enemyIndex = UnityEngine.Random.Range(0, EnemyPrefabs.Length);
        int PositionValue = EnemyPosition[UnityEngine.Random.Range(0, EnemyPosition.Length)];

        Vector3 spawnPos = new Vector3(PositionValue, 1, -spawnZ);

        Quaternion Rotation = Quaternion.LookRotation(Vector3.back);

        Instantiate(EnemyPrefabs[enemyIndex], spawnPos, Rotation);
        transform.Translate(Vector3.back * Time.deltaTime * speed);

    }

    void SpawnEnemyLeft()
    {
        int enemyIndex = UnityEngine.Random.Range(0, EnemyPrefabs.Length);
        int PositionValue = EnemyPosition[UnityEngine.Random.Range(0, EnemyPosition.Length)];

        Vector3 spawnPos = new Vector3(-spawnZ, 1, PositionValue);

        Quaternion Rotation = Quaternion.LookRotation(Vector3.left);

        Instantiate(EnemyPrefabs[enemyIndex], spawnPos, Rotation);
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    void SpawnEnemyRight()
    {
        int enemyIndex = UnityEngine.Random.Range(0, EnemyPrefabs.Length);
        int PositionValue = EnemyPosition[UnityEngine.Random.Range(0, EnemyPosition.Length)];

        Vector3 spawnPos = new Vector3(spawnZ, 1, PositionValue);

        Quaternion Rotation = Quaternion.LookRotation(Vector3.right);

        Instantiate(EnemyPrefabs[enemyIndex], spawnPos, Rotation);
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
