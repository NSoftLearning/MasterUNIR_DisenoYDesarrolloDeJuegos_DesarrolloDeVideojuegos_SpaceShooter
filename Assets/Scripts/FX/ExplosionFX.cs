using UnityEngine;

public class ExplosionFX : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;

    public void Initialize(AudioClip audioClip, Vector3 scale)
    {
        transform.localScale = scale;
        _audioSource.clip = audioClip;
        _audioSource.Play();

    }
    public void ClearExplosion (string s)
    {
        Destroy(gameObject);
    }
    
}
