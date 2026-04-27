using UnityEngine;

public class ResetGameStatus : MonoBehaviour
{
    [SerializeField] GameStatusSO _gameStatusSO;

    private void Start()
    {
        _gameStatusSO.ResetGameStatus();
    }

}
