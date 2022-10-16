using UnityEngine;

public class MAPositionAutoDestroyer : MonoBehaviour
{
    [SerializeField]
    private Vector3 destroyPosition;

    private void LateUpdate()
    {
        if ( (destroyPosition-transform.position).sqrMagnitude < 0.1f )
        {
            Destroy(gameObject);
        }
    }
}
