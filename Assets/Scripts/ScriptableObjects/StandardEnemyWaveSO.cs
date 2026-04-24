using UnityEngine;

[CreateAssetMenu (fileName = "StandardEnemyWave", menuName = "ScriptableObjects/EnemyWaves/StandardEnemyWave")]
public class StandardEnemyWaveSO : ScriptableObject, IEnemyFactory
{
    public float startDelay;
    public Enemy enemyType;
    public float enemyToEnemyDelay;
    public float enemyQuantity;
    public SpawnPointAdjustment spawnPointAdjustment;
    public bool requiresDestructionToEndwave;
    public bool IsEndOfLevel;
  
    public virtual Enemy CreateEnemy (Vector3 position, Quaternion rotation)
    {
       Enemy newEnemy =  Instantiate(enemyType, position, rotation);
       newEnemy.enemyDiedAction += ComponentLocatorService.Components.GameStatus.HandleEnemyDead;



       return newEnemy;
    }

    public WaveData GetWaveData()
    {
        return new WaveData(
            startDelay, 
            enemyToEnemyDelay, 
            enemyQuantity, 
            spawnPointAdjustment, 
            requiresDestructionToEndwave,
            IsEndOfLevel);
    }
}
