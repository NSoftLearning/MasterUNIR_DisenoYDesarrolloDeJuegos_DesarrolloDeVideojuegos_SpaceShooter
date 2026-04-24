using UnityEngine;

[CreateAssetMenu(fileName = "NewZigzagEnemyWave", menuName = "ScriptableObjects/EnemyWaves/ZigzagEnemyWave")]
public class ZigzagEnemyWaveSO : StandardEnemyWaveSO
{
    public float amplitude = 5;
    public float forwardSpeed = -5;
    public float zigzagSpeed = 1;
    public bool firstGoDown;

    public override Enemy CreateEnemy(Vector3 position, Quaternion rotation)
    {


        Enemy createdEnemy = base.CreateEnemy (position, rotation);
        createdEnemy.GetComponent<ZigzagMovement>().Initialize(amplitude, forwardSpeed, zigzagSpeed, firstGoDown, position);
        return createdEnemy;

    }


}
