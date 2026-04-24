using System;
using System.Collections;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public SpawnPointSO spawnPointIdentifier;
    [SerializeField] EnemiesAttackVector enemiesAttackVector;
    [SerializeField] EnemySpawnerStates _currentState;

    [SerializeField] int _currentWave;
    float _nextSpawnTime;
    float _nextWaveArrivalTime;
    int _enemiesSpawnedInCurrentWave;
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
            switch (_currentState)
        {
            case EnemySpawnerStates.WaitingForNextWave:
                if (Time.time > _nextWaveArrivalTime)
                {
                    _currentState = EnemySpawnerStates.SpawiningWave;
                    _nextSpawnTime = Time.time + enemiesAttackVector.GetWaveData(_currentWave).enemyToEnemyDelay;
                    _enemiesSpawnedInCurrentWave = 0;
                }
                break;
            
            case EnemySpawnerStates.SpawiningWave:

                if (Time.time < _nextSpawnTime)
                    break;
                
                
                enemiesAttackVector.
                    CreateEnemyFromWave(
                    _currentWave, 
                    CalculateSpawnPointAdjustedPosition (enemiesAttackVector.GetWaveData(_currentWave).spawnPointAdjustment),
                    transform.rotation);
                _enemiesSpawnedInCurrentWave++;
                _nextSpawnTime = Time.time + enemiesAttackVector.GetWaveData(_currentWave).enemyToEnemyDelay;

                Debug.Log("SPAWNED ENEMY " + this.name + " wave " + _currentWave);

               
                if (_enemiesSpawnedInCurrentWave == enemiesAttackVector.GetWaveData(_currentWave).enemyQuantity)
                {
                    _currentWave++;


                    if (_currentWave >= enemiesAttackVector.GetWavesCount())
                        _currentState = EnemySpawnerStates.AllWavesSpawned;
                    else
                    {
                        _nextWaveArrivalTime = Time.time + enemiesAttackVector.GetWaveData(_currentWave).startDelay;
                        _currentState = EnemySpawnerStates.WaitingForNextWave;
                    }
                }



                break;

        }

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
    