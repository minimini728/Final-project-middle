using UnityEngine;

public class JUPlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private Color[] platformColors;
    [SerializeField]
    private Material platformMaterial;

    [SerializeField]
    private GameObject platformPrefab;
    [SerializeField]
    private int spawnPlatformCountAtStart = 8;
    [SerializeField]
    private float xRange = 4;
    [SerializeField]
    private float zDistance = 5;
    private int platformIndex = 0;

    public float ZDistance => zDistance;

    private void Awake()
    {
        platformMaterial.color = platformColors[0];

        for(int i = 0; i < spawnPlatformCountAtStart; ++i)
        {
            SpawnPlatform();
        }
    }

    public void SpawnPlatform()
    {
        GameObject clone = Instantiate(platformPrefab);
        clone.GetComponent<JUPlatform>().Setup(this);
        ResetPlatform(clone.transform);
    }

    public void ResetPlatform(Transform transform, float y = 0)
    {
        platformIndex ++;
        float x = Random.Range(-xRange, xRange);
        transform.position = new Vector3(x, y, platformIndex * zDistance);
    }

    public void SetPlatformColor()
    {
        int index = Random.Range(0, platformColors.Length);
        platformMaterial.color = platformColors[index];
    }
}
