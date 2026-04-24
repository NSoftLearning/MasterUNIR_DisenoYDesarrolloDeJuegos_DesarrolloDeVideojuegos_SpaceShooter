using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu( fileName = "EnemyAttackVector", menuName = "ScriptableObjects/EnemyWaves/EnemyAttackVector")]
public class EnemiesAttackVector : ScriptableObject
{
    public SpawnPointSO targetSpawnPoint;
    [SerializeField] List<StandardEnemyWaveSO> enemyWaves;
    

    public  WaveData GetWaveData (int waveIndex)
    {
        WaveData waveData =(enemyWaves[waveIndex] as IEnemyFactory).GetWaveData();
        return waveData;
    }
    public Enemy CreateEnemyFromWave (int waveIndex, Vector3 enemyPosition, Quaternion enemyRotation)
    {
       
        return (enemyWaves[waveIndex] as IEnemyFactory).CreateEnemy(enemyPosition, enemyRotation);
    }
    public int GetWavesCount()
    {
        return enemyWaves.Count;
    }     
}
