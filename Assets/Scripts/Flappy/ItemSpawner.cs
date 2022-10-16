using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject item;
    Vector2 itemSpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnItem", 2f, 2f);
    }

    // Update is called once per frame
    void SpawnItem()
    {
        int randomValue = (int)Random.Range(0f, 2f);

        switch (randomValue)
        {
            case 0:
                itemSpawnPos = new Vector2(transform.position.x, 2.7f);
                break;
            case 1:
                itemSpawnPos = new Vector2(transform.position.x, -2.7f);
                break;
            case 2:
                itemSpawnPos = new Vector2(transform.position.x, 0f);
                break;
        }

        Instantiate(item, itemSpawnPos, Quaternion.identity);
    }
}
