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
        // GetComponentsInChildren<Transform>() �� ���� Spawner�� ��ġ���� spawnPoint �迭�� 0������ ���⶧���� 1����
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;

    }
}
