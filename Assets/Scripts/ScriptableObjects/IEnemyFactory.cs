using UnityEngine;

interface IEnemyFactory
{
    public Enemy CreateEnemy(Vector3 position, Quaternion rotation);
    public WaveData GetWaveData();
}