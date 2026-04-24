using System;
using System.Collections;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public SpawnPointSO spawnPointIdentifier;
    [SerializeField] EnemiesAttackVector enemiesAttackVector;
    [SerializeField] public EnemySpawnerStates currentState;

    [SerializeField] int _currentWave;
    float _nextSpawnTime;
    float _nextWaveArrivalTime;
    int _enemiesSpawnedInCurrentWave;
    


    public event Action EndOfLevelReached;
    public event Action StartPauseForNextWave;
    public event Action<Enemy> EnemySpawned;

    public void Initialize(EnemiesAttackVector attackVector)
    {
        int currentWave = 0;       
        enemiesAttackVector = attackVector;

        if (enemiesAttackVector == null || enemiesAttackVector.GetWavesCount() == 0)
        {
            enabled = false;
            return;
        }

        _enemiesSpawnedInCurrentWave = 0;
        _nextWaveArrivalTime = Time.time + enemiesAttackVector.GetWaveData(currentWave).startDelay;
    }

    private void Update()
    {
        if (enemiesAttackVector == null)
        {
            enabled = false;
            return;
        }
            switch (currentState)
            { 
             
            case EnemySpawnerStates.WaitingForNextWave:
                if (_enemiesSpawnedInCurrentWave == enemiesAttackVector.GetWaveData(_currentWave).enemyQuantity)
                {
                    _currentWave++;
                    currentState = EnemySpawnerStates.Paused;
                    break;
                }

                if (Time.time > _nextWaveArrivalTime)
                {
                    currentState = EnemySpawnerStates.SpawiningWave;
                    _nextSpawnTime = Time.time + enemiesAttackVector.GetWaveData(_currentWave).enemyToEnemyDelay;
                    _enemiesSpawnedInCurrentWave = 0;
                }
                break;

            case EnemySpawnerStates.SpawiningWave:

                if (Time.time < _nextSpawnTime)
                    break;

                SpawnEnemy();

                if (_enemiesSpawnedInCurrentWave == enemiesAttackVector.GetWaveData(_currentWave).enemyQuantity)
                {
                    _currentWave++;

                    if (_currentWave >= enemiesAttackVector.GetWavesCount())
                    {
                        currentState = EnemySpawnerStates.AllWavesSpawned;

                    }
                    else
                    {
                        currentState = EnemySpawnerStates.Paused;
                        StartPauseForNextWave.Invoke();
                    }
                }
                break;
        }

    }

    private void SpawnEnemy()
    {
        Enemy newEnemy = enemiesAttackVector.
            CreateEnemyFromWave(
            _currentWave,
            CalculateSpawnPointAdjustedPosition(enemiesAttackVector.GetWaveData(_currentWave).spawnPointAdjustment),
            transform.rotation);
        _enemiesSpawnedInCurrentWave++;
        _nextSpawnTime = Time.time + enemiesAttackVector.GetWaveData(_currentWave).enemyToEnemyDelay;

        if (enemiesAttackVector.GetWaveData(_currentWave).enemiesMustBeDestroyed)
        {
            EnemySpawned.Invoke(newEnemy);

        }
    }

    public void ResumeFromPaused ()
    {
        if (currentState == EnemySpawnerStates.AllWavesSpawned)
            return;

        if (enemiesAttackVector.GetWaveData(_currentWave).isEndOfLevel)
        {
            EndOfLevelReached.Invoke();
            return;
        }

        _enemiesSpawnedInCurrentWave = 0;
        _nextWaveArrivalTime = Time.time + enemiesAttackVector.GetWaveData(_currentWave).startDelay;
        currentState = EnemySpawnerStates.WaitingForNextWave;

    }

    Vector3 CalculateSpawnPointAdjustedPosition(SpawnPointAdjustment adjustment)
    {
        switch (adjustment)
        {
            case SpawnPointAdjustment.None:
                return transform.position;

            case SpawnPointAdjustment.SemiRandom:
                float verticalOffset = UnityEngine.Random.Range(-3, 3);
                return transform.position + Vector3.up * verticalOffset;

            case SpawnPointAdjustment.FacingPlayer:
                float verticalPosition = ComponentLocatorService.Components.PlayerTransform.position.y;
                return new Vector3(transform.position.x, verticalPosition, transform.position.z);

                


        }


        return Vector3.up;
    }

}
    