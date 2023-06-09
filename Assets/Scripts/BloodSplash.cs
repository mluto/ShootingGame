using UnityEngine;

public class BloodSplash : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;

    void Start()
    {
        particleSystem.Play();
    }

    void Update()
    {
        if (!particleSystem.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
