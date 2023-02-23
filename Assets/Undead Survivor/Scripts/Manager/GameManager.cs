using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    [Header("# Game Control")]
    public float gameTime;
    public float maxGameTime = 600f;
    [Header("# Player Info")]
    public int health;
    public int maxHealth = 100;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = new int[15];
    [Header("# Game Object")]
    public PoolManager pool;
    public Player player;

    void Awake()
    {
        instance = this;
        for (int i = 0; i < nextExp.Length; i++)
        {
            CalculateLevel(i);
        }
    }

    void Start()
    {
        health = maxHealth;

        
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

    public void CalculateLevel(int index)
    {
        const int setLevel = 10;
        int levelWeight = 5;
        nextExp[index] = Mathf.FloorToInt(setLevel+ Mathf.Pow(levelWeight * index, 1.5f));      
    }
}
