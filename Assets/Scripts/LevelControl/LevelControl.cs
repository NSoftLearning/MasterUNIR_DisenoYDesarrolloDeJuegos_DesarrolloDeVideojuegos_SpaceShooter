using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    [SerializeField] public List<EnemySpawner> _enemySpanwers;
    [SerializeField] LevelsLibrarySO _levelsLibrary;
    [SerializeField] GameStatusSO _gameStatus;
    [SerializeField] int _mustDestroyCount;

    bool endOfLevelEventAlreadyCaptured;
    public event Action LevelFinished;

    public void Start()
    {
        endOfLevelEventAlreadyCaptured = false;
        _mustDestroyCount = 0;
        LevelDataSO currentLevelData = _levelsLibrary.levelsData[ComponentLocatorService.Components.GameStatus._currentGameLevel];
        foreach (EnemiesAttackVector enemiesAttackVector in currentLevelData._enemiesAttackVectors)
        {
            EnemySpawner spawnPoint = _enemySpanwers.Find(x => x.spawnPointIdentifier == enemiesAttackVector.targetSpawnPoint);
            spawnPoint.Initialize(enemiesAttackVector);


            spawnPoint.StartPauseForNextWave += CheckWavesStatus;
            spawnPoint.EnemySpawned += HandleNewEnemyCreated;
            spawnPoint.EndOfLevelReached += HandleAllWavesFinished;
        }


        GameObject background = Instantiate(
            _levelsLibrary.levelsData[ComponentLocatorService.Components.GameStatus._currentGameLevel]._levelBackground,
            Vector3.zero + Vector3.up * _levelsLibrary.levelsData[ComponentLocatorService.Components.GameStatus._currentGameLevel]._verticalOffset,
            Quaternion.identity);
    }

    private void HandleAllWavesFinished()
    {
        if (endOfLevelEventAlreadyCaptured)
            return;
        endOfLevelEventAlreadyCaptured = true;


        _gameStatus._currentGameLevel++;
        LevelFinished?.Invoke();        
    }

    private void HandleNewEnemyCreated(Enemy enemy)
    {
        _mustDestroyCount++;
        enemy.damageableDiedAction += DecreaseMustDestroyCount;
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
        LevelDataSO currentLevelData = _levelsLibrary.levelsData[ComponentLocatorService.Components.GameStatus._currentGameLevel];
        foreach (EnemiesAttackVector enemiesAttackVector in currentLevelData._enemiesAttackVectors)
        {
            EnemySpawner spawnPoint = _enemySpanwers.Find(x => x.spawnPointIdentifier == enemiesAttackVector.targetSpawnPoint);

            spawnPoint.StartPauseForNextWave -= CheckWavesStatus;
        }
    }
}

