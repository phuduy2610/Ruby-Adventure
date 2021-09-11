using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedEnemy;
    private int randomIndex;
    private int randomSide;

    [SerializeField]
    private Transform leftPos, rightPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);
            spawnedEnemy = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0)
            {
                spawnedEnemy.transform.position = leftPos.position;
                spawnedEnemy.GetComponent<Enemy>().speed = Random.Range(4, 10);
            }
            else
            {
                spawnedEnemy.transform.position = rightPos.position;
                spawnedEnemy.GetComponent<Enemy>().speed = -Random.Range(4, 10);
                spawnedEnemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
