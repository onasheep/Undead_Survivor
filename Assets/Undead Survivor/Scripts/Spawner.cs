using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.2f) {
            Spawn();
            timer = 0;
        }
       
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, 2));
        // GetComponentsInChildren<Transform>() 로 인해 Spawner의 위치값이 spawnPoint 배열의 0번쨰로 들어가기때문에 1부터
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;

    }
}
