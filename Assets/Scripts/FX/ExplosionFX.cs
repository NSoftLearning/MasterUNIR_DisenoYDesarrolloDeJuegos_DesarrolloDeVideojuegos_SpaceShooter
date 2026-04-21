using UnityEngine;

public class ExplosionFX : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;

    public void Initialize(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();

    }

    public void ClearExplosion (string s)
    {
        Destroy(gameObject);
    }
    
}
