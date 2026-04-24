using System;
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

            spawnPoint.StartPauseForNextWave += CheckWavesStatus;
        }       
    }

    private void CheckWavesStatus()
    {
        bool allWavesPaused = true;
        foreach (EnemySpawner enemySpawner in _enemySpanwers)
        {
            if (enemySpawner.currentState != EnemySpawnerStates.Paused)
            {
                allWavesPaused = false;
                break;
            }
        }

        if (allWavesPaused)
        {
            foreach (EnemySpawner enemySpawner in _enemySpanwers)
            {
                enemySpawner.ResumeFromPaused();
            }

        }

        //si all waves finished = true esperar unos segundos y terminar nivel.¿¿??

    }

    private void OnDestroy()
    {
        LevelDataSO currentLevelData = _levelsLibrary.levelsData[ComponentLocatorService.Components.GameStatus._currentLevel];
        foreach (EnemiesAttackVector enemiesAttackVector in currentLevelData._enemiesAttackVectors)
        {
            EnemySpawner spawnPoint = _enemySpanwers.Find(x => x.spawnPointIdentifier == enemiesAttackVector.targetSpawnPoint);

            spawnPoint.StartPauseForNextWave -= CheckWavesStatus;
        }
    }
}

