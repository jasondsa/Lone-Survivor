using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies2 : MonoBehaviour
{
    public GameObject theEnemy;
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
        while (enemyCount < 2)
        {
            xPos = Random.Range(6, 37);
            yPos = 12;
            zPos = Random.Range(-207, -210);
            Instantiate(theEnemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;

        }
    }

}
