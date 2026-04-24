using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    [SerializeField] public List<EnemySpawner> _enemySpanwers;
    [SerializeField] LevelsLibrarySO _levelsLibrary;

    [SerializeField] int _mustDestroyCount;

    bool endOfLevelEventAlreadyCaptured;

    public void Start ()
    {
        endOfLevelEventAlreadyCaptured = false;
        _mustDestroyCount = 0;
        LevelDataSO currentLevelData = _levelsLibrary.levelsData[ComponentLocatorService.Components.GameStatus._currentLevel];
        foreach (EnemiesAttackVector enemiesAttackVector in currentLevelData._enemiesAttackVectors)
        {
            EnemySpawner spawnPoint = _enemySpanwers.Find(x => x.spawnPointIdentifier == enemiesAttackVector.targetSpawnPoint);
            spawnPoint.Initialize(enemiesAttackVector);
            

            spawnPoint.StartPauseForNextWave += CheckWavesStatus;
            spawnPoint.EnemySpawned += HandleNewEnemyCreated;
            spawnPoint.EndOfLevelReached += HandleAllWavesFinished;
        }       
    }

    private void HandleAllWavesFinished()
    {
        if (endOfLevelEventAlreadyCaptured)
            return;
        endOfLevelEventAlreadyCaptured = true;


        Debug.Log("---- LEVEL IS FINISHED -----");
    }

    private void HandleNewEnemyCreated(Enemy enemy)
    {
        _mustDestroyCount++;
        enemy.enemyDiedAction += DecreaseMustDestroyCount;
    }

   void DecreaseMustDestroyCount(DamageableDestroyedData data)
    {
        _mustDestroyCount--;
        CheckWavesStatus();
    }

    private void CheckWavesStatus()
    {
        if (_mustDestroyCount != 0)
            return;

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

