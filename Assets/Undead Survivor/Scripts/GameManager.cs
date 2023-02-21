using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    [Header("# Gmae Control")]
    public float gameTime;
    public float maxGameTime = 2 * 10f;
    [Header("# Player Info")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    [Header("# Game Object")]
    public PoolManager pool;
    public Player player;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }

    }

    public void GetExp()
    {
        exp++;

        if (exp == nextExp[level])
        {
            level++;
            exp = 0;

        }
    }
}
