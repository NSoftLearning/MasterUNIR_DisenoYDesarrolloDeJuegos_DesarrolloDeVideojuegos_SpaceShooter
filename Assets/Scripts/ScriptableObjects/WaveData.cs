using UnityEngine;

public struct WaveData
{
    public float startDelay;
    public float enemyToEnemyDelay;
    public float enemyQuantity;
    public SpawnPointAdjustment spawnPointAdjustment;

    public WaveData (float  startDelay, float enemyToEnemyDelay, float enemyQuantity, SpawnPointAdjustment spawnPointAdjustment)
    {
        this.startDelay = startDelay;
        this.enemyToEnemyDelay = enemyToEnemyDelay;
        this.enemyQuantity = enemyQuantity;
        this.spawnPointAdjustment = spawnPointAdjustment;
    }

}
