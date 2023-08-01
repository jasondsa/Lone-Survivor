using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public GameObject theEnemy2;
    public int xPos;
    public int yPos;
    public int zPos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 5)
        {
            xPos = Random.Range(10, -6);
            yPos = 13;
            zPos = Random.Range(-217, -223);
            Instantiate(theEnemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            Instantiate(theEnemy2, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 2;

        }
    }

}
