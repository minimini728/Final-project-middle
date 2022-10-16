using UnityEngine;

public class MACubeSelector : MonoBehaviour
{
    private MAObjectDetector objectDetector;

    private void Awake()
    {        
            objectDetector = GetComponent<MAObjectDetector>();

            objectDetector.raycastEvent.AddListener(SelectCube);
    }

    public void SelectCube(Transform hit)
    {
        hit.GetComponent<MACubeController>().ChangeColor();
    }
}
