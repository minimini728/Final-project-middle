using System.Collections;
using UnityEngine;

public class JUPlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject coinObject;
    [SerializeField]
    private int coinSpawnPercent = 50;

    private JUPlatformSpawner platformSpawner;
    private Camera mainCamera;
    private float yMoveTime = 0.5f;

    public void Setup(JUPlatformSpawner platformSpawner)
    {
        this.platformSpawner = platformSpawner;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (mainCamera.transform.position.z - transform.position.z > 0)
        {
            SpawnCoin();

            platformSpawner.ResetPlatform(this.transform);
            StartCoroutine(MoveY(10, 0));
        }
    }

    private IEnumerator MoveY(float start, float end)
    {
        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / yMoveTime;

            float y = Mathf.Lerp(start, end, percent);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);

            yield return null;
        }
    }

    private void SpawnCoin()
    {
        int percent = Random.Range(0, 100);

        if(percent < coinSpawnPercent)
        {
            coinObject.SetActive(true);
        }
        else
        {
            coinObject.SetActive(false);
        }
    }
}
