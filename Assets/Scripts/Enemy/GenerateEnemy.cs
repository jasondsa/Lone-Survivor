using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
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
            while (enemyCount < 200)
            {
                xPos = Random.Range(65, 192);
                yPos = Random.Range(22, 30);
                zPos = Random.Range(114, 225);
                Instantiate(theEnemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                enemyCount += 1;
            }
        }
    
}
