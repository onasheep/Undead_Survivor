using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리랩을 보관할 변수
    public GameObject[] prefabs;

    // 풀 담당을 하는 리스트들
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }

    }

    public GameObject Get(int index)
    {
        GameObject select = null;
        // 선택한 풀의 놀고 있는(비활성화된) 게임 오브젝트에 접근
        // 발견 하면 select 변수에 할당
        foreach (GameObject item in pools[index])
        {
            if(!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // 못찾았다면??
        // 새롭게 생성하고 select 변수에 할당
        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select); // 동적으로 추가 가능!! 자동으로 크기가 늘어남!!
        }
        


        return select;
    }
}
