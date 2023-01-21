using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    Clock clock;
    public GameObject[] enemy;

    // number of enemy
    int numberE;

    private void Start()
    {
        clock = GameObject.Find("Clock").GetComponent<Clock>();
        numberE = 0;
    }

    private void Update()
    {
        if (!clock.day && numberE < 2)
        {
            Spawn(enemy[0]);
        }
    }

    void Spawn(GameObject gameObject)
    {
        Vector3 spawnPosition;
        if (numberE == 1)
            spawnPosition = new Vector3(0, 6, 0);
        else
            spawnPosition = new Vector3(-1, 7, 0);

        GameObject instance = Instantiate(gameObject);
        instance.transform.SetPositionAndRotation(spawnPosition, Quaternion.identity);
        numberE++;

    }
}
