using UnityEngine;

public class JUCameraController : MonoBehaviour
{
    [SerializeField]
    public Transform target;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 position = transform.position;
        position.z = target.position.z - 10;
        transform.position = position;
    }
}
