using UnityEngine;

public class JUParticleAutoDestroyer : MonoBehaviour
{
    private ParticleSystem particle;

    private void Awake()
    {
        if (particle.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
