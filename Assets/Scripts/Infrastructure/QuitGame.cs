using UnityEngine;

public class QuitGame : MonoBehaviour
{

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        
#endif
        gameObject.SetActive(false);
    }
    public void ExitGame ()
    {


        Application.Quit();
    }
}
