using System.Collections.Generic;
using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    [SerializeField] public List<EnemySpawner> _enemySpanwers;
    [SerializeField] LevelsLibrarySO _levelsLibrary;

    public void Start ()
    {
        LevelDataSO currentLevelData = _levelsLibrary.levelsData[ComponentLocatorService.Components.GameStatus._currentLevel];
        foreach (EnemiesAttackVector enemiesAttackVector in currentLevelData._enemiesAttackVectors)
        {
            EnemySpawner spawnPoint = _enemySpanwers.Find(x => x.spawnPointIdentifier == enemiesAttackVector.targetSpawnPoint);
            spawnPoint.Initialize(enemiesAttackVector);
        }

       
    }

}

