using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStatus", menuName = "ScriptableObjects/GameStatus", order = 1)]
public class GameStatusSO : ScriptableObject
{
    [SerializeField] int _score;
    [SerializeField] int _cash;

    public Action<int> scoreChanged;


    public  void HandleEnemyDead (DamageableDestroyedData enemyDeadData)
    {
        _score += enemyDeadData.scoreModifier;
        _cash += enemyDeadData.currencyModifier;         
    }


}
