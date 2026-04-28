using TMPro;
using UnityEngine;

public class PlayerDeadUIController : MonoBehaviour
{
    [SerializeField] TMP_Text _score;
    [SerializeField] GameStatusSO _gameStatus;

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Show ()
    {
        _score.text = "Your score: " + _gameStatus.score;
        gameObject.SetActive(true);
    }
}
