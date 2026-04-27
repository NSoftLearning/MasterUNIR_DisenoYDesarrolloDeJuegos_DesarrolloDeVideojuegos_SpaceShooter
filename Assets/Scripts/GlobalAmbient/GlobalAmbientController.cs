using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalAmbientController : MonoBehaviour
{
    [SerializeField] Animator _animator;


    public void Start()
    {
        FadeIn();
    }

    public void FadeIn ()
    {
        _animator.SetTrigger("FadeIn");
    }

    public void FadeOut()
    {
        _animator.SetTrigger("FadeOut");
    }


    public void RequestLevelChange (string targetLevel)
    {
        float animationDuration = GetAnimationDuration("FadeOut") + .5f;

        FadeOut();
        StartCoroutine(LevelChangeCoroutime(targetLevel, animationDuration));

    }

    float GetAnimationDuration (string animationName)
    {
        AnimationClip animation = 
            _animator.runtimeAnimatorController.animationClips
            .FirstOrDefault (x => x.name == animationName);

        return animation.length;
    }

    IEnumerator LevelChangeCoroutime (string targetScene, float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        SceneManager.LoadScene(targetScene);
    }
}
