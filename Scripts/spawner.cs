using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool spawnerTop = true;
    private bool canSpawn = true;


    private void Start(){
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner() {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn) {
            yield return wait;
            int rand = Random.Range(0,enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rand];
            if(spawnerTop){
                Vector2 spawnPoint = new Vector2(Random.Range(-4f,4f), transform.position.y);
                Instantiate(enemyToSpawn, spawnPoint, Quaternion.identity);
            } else {
                Vector2 spawnPoint = new Vector2(transform.position.x, Random.Range(-4f,4f));
                Instantiate(enemyToSpawn, spawnPoint, Quaternion.identity);
            }
            
        }
    }

}
