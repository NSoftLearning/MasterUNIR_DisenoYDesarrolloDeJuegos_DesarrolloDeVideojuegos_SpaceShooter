using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu( fileName = "EnemyAttackVector", menuName = "ScriptableObjects/EnemyWaves/EnemyAttackVector")]
public class EnemiesAttackVector : ScriptableObject
{
    public SpawnPointSO targetSpawnPoint;
    [SerializeField] List<ScriptableObject> enemyWaves;
    

    public  WaveData GetWaveData (int waveIndex)
    {
       return (enemyWaves[waveIndex] as IEnemyFactory).GetWaveData();
    }
    public void CreateEnemyFromWave (int waveIndex, Vector3 enemyPosition, Quaternion enemyRotation)
    {
       
        (enemyWaves[waveIndex] as IEnemyFactory).CreateEnemy(enemyPosition, enemyRotation);
    }
    public int GetWavesCount()
    {
        return enemyWaves.Count;
    }     
}
