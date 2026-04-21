using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private GameStatusSO gameStatus;
    private void Start()
    {
        StartCoroutine(SpawnEnemies()); 
    }

    IEnumerator SpawnEnemies ()
    {

        for (int i = 0; i< 10; i++) {

            Enemy newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            newEnemy.enemyDied.AddListener(gameStatus.HandleEnemyDead);

            yield return new WaitForSeconds(.35f);

        }
    }


}
