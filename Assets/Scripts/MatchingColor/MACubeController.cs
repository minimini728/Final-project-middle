using UnityEngine;

public class MACubeController : MonoBehaviour
{
    private MACubeSpawner cubeSpawner;
    private MACubeChecker cubeChecker;
    private MeshRenderer meshRenderer;
    private int colorIndex;

    public void Setup(MACubeSpawner cubeSpawner, MACubeChecker cubeChecker)
    {
        this.cubeSpawner = cubeSpawner;
        this.cubeChecker = cubeChecker;

        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = this.cubeSpawner.CubeColors[0];
        colorIndex = 0;
    }

    public void ChangeColor()
    {
        if (colorIndex < cubeSpawner.CubeColors.Length-1)
        {
            colorIndex++;
        }
        else
        {
            colorIndex = 0;
        }

        meshRenderer.material.color = cubeSpawner.CubeColors[colorIndex];
    }

    private void OnTriggerEnter(Collider other)
    {
        MeshRenderer renderer = other.GetComponent<MeshRenderer>();

        if(meshRenderer.material.color == renderer.material.color)
        {
            cubeChecker.CorrectCount++;
        }
        else
        {
            cubeChecker.IncorrectCount++;
        }
    }
}
