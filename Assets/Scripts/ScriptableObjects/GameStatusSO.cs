using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStatus", menuName = "ScriptableObjects/GameStatus", order = 1)]
public class GameStatusSO : ScriptableObject
{
    [SerializeField] public LevelsLibrarySO levelsLibrary;
    [SerializeField] public int score;
    [SerializeField] public int cash;
    [SerializeField] int _nextLevel;
    [SerializeField] public  bool topSlotWeaponSet;
    [SerializeField] public int topSlotWeaponIndex;
    [SerializeField] public bool bottomSlotWeaponSet;
    [SerializeField] public int bottomSlotWeaponIndex;


    public int _currentGameLevel;


    public Action<int> scoreChanged;
    public Action<int> cashChanged;

    public  void HandleEnemyDead (DamageableDestroyedData enemyDeadData)
    {
        score += enemyDeadData.scoreModifier;
        cash += enemyDeadData.currencyModifier;

        RequestForFreshData();

    }

    public void RequestForFreshData ()
    {
        scoreChanged.Invoke(score);
        cashChanged.Invoke(cash);
    }


    [ContextMenu(nameof(ResetGameStatus))]
    public void ResetGameStatus ()
    {
      //  score = 0;
    //    cash = 0;
     //   _currentGameLevel = 0;
     //   _nextLevel = 0;
    }


}
