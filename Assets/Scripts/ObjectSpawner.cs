using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private GameManager GameManager;
    public GameObject[] myObjects;
    private int RandomObj;
    private float NextObjectTime;
    private float SpawnRate = 1f;

    void Start()
    {
        GameManager = GameObject.Find("Prefab_UI").GetComponent<GameManager>();
    }

    void Update()
    {
        if(GameManager.CurrentState != GameManager.GameState.GameIdle)
        {
            if (Time.time >= NextObjectTime)
            {
                RandomObj = Random.Range(0, myObjects.Length);
                SpawnObject();
                NextObjectTime = Time.time + SpawnRate;
            }
        }     
    }

    void SpawnObject()
    {
        float xPosition = Random.Range(-3, 3);
        Vector3 SpawnPos = transform.position + new Vector3(xPosition, 0, 0);
        Instantiate(myObjects[RandomObj], SpawnPos, Quaternion.identity);
    }
}
