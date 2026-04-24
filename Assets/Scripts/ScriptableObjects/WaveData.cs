using UnityEngine;

public struct WaveData
{
    public float startDelay;
    public float enemyToEnemyDelay;
    public float enemyQuantity;
    public SpawnPointAdjustment spawnPointAdjustment;
    public bool enemiesMustBeDestroyed;
    public bool isEndOfLevel;
   

    public WaveData (
        float  startDelay, 
        float enemyToEnemyDelay, 
        float enemyQuantity, 
        SpawnPointAdjustment spawnPointAdjustment,
        bool enemiesMustBeDestroyed,
        bool isEndOfLevel)
    {
        this.startDelay = startDelay;
        this.enemyToEnemyDelay = enemyToEnemyDelay;
        this.enemyQuantity = enemyQuantity;
        this.spawnPointAdjustment = spawnPointAdjustment;
        this.enemiesMustBeDestroyed = enemiesMustBeDestroyed;
        this.isEndOfLevel = isEndOfLevel;
        
    }

}
