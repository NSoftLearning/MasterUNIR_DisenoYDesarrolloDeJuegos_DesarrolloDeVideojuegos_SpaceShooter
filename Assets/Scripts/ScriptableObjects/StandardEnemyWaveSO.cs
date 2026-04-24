using UnityEngine;

[CreateAssetMenu (fileName = "NewEnemyGroup",menuName = "ScriptableObjects/EnemyWaves/NewEnemyGroup")]
public class StandardEnemyWaveSO : ScriptableObject, IEnemyFactory
{
    public float startDelay;
    public Enemy enemyType;
    public float enemyToEnemyDelay;
    public float enemyQuantity;
    public SpawnPointAdjustment spawnPointAdjustment;
    

  
    public Enemy CreateEnemy (Vector3 position, Quaternion rotation)
    {
        return Instantiate(enemyType, position, rotation);
    }

    public WaveData GetWaveData()
    {
        return new WaveData(startDelay, enemyToEnemyDelay, enemyQuantity, spawnPointAdjustment);
    }
}
