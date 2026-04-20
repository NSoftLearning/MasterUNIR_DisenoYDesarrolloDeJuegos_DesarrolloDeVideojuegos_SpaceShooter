using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private void Start()
    {
        StartCoroutine(SpawnEnemies()); 
    }

    IEnumerator SpawnEnemies ()
    {

        for (int i = 0; i< 10; i++) {
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(.35f);

        }
    }
}
