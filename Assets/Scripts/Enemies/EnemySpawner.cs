using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private GameStatusSO gameStatus;
    [SerializeField] private int quantity;
    private void Start()
    {
        StartCoroutine(SpawnEnemies()); 
    }

    IEnumerator SpawnEnemies ()
    {

        for (int i = 0; i< quantity; i++) {
            SpawnSingleEnemy();
           yield return new WaitForSeconds(.35f);

        }
    }


    [ContextMenu(nameof (SpawnSingleEnemy))]
    public void SpawnSingleEnemy ()
    {
        Enemy newEnemy = Instantiate(enemy, transform.position, transform.rotation);
        newEnemy.enemyDiedAction += gameStatus.HandleEnemyDead;
    }

}
