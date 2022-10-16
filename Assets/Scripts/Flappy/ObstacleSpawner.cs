using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 3f, 2f);
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        int obstacleNum = Random.Range(0, obstacles.Length);

        Instantiate(obstacles[obstacleNum], transform.position, Quaternion.identity);
    }
}
