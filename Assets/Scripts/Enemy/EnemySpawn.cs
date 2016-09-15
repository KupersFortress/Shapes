using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn enemySpawn;
    public int destroyedEnemyCount;
    [SerializeField]
    float spawnDelay;
    //[SerializeField]
    int enemyCount;
    [SerializeField]
    int maxEnemyCount;
    public Line[] lines;
    public Pool[] pools;
    bool isSpawning;
    //public List<int> enemiesOnLine;
    //[SerializeField]
    //bool moveByCurve;
    //int enemyTypeCount;


    void Start()
    {
        enemySpawn = this;
        destroyedEnemyCount = 0;
        enemyCount = 0;
        //enemyTypeCount = pools.Length;
        StartCoroutine(Spawn());
        
        isSpawning = true;

    }

    void Update()
    {
        if (destroyedEnemyCount >= maxEnemyCount)
            MainController.mainController.NextLevel();
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1.0f);
        while (isSpawning)
        {
            if (enemyCount >= maxEnemyCount)
            {
                isSpawning = false;
                yield return null;
            }
            else
            {
                GenerateMultipleEnemies();
                yield return new WaitForSeconds(spawnDelay + Random.value/2.0f);
            }

        }
    }

    void GenerateMultipleEnemies()
    {
        List<int> enemiesOnLine = new List<int>();
        //List<int> enemiesOnLine = new List<int>();
        int j = (int)Random.Range(0, pools.Length);
        enemiesOnLine.Add(j);
        //print(enemiesOnLine[0]);
        int h = (int)Random.Range(0, lines.Length);
        bool leftPosition= Random.value > 0.5 ?
                        true : false;
        Vector3 position = leftPosition ?
                        lines[h].spawnPositions[0].position : lines[h].spawnPositions[1].position;
        GameObject obj=(GameObject)pools[j].Activate(position, Quaternion.identity);

        
            obj.GetComponent<EnemyMove>().leftDirection = !leftPosition;
        

        enemyCount++;
        if (lines[h].curve != null)
        {
            obj.GetComponent<EnemyMove>().mgCurve = lines[h].curve;
        }
        obj.GetComponent<EnemyMove>().MoveByCurve();
        for (int i = 0; i < lines.Length; i++)
        {
            if (Random.value > 0.2f)
            {
                int l = (int)Random.Range(0, pools.Length);

                if (!enemiesOnLine.Contains(l))

                {
                    //print(l);
                    //print(enemiesOnLine.Contains(l));
                    enemiesOnLine.Add(l);
                    obj = pools[l].Activate(position, Quaternion.identity);
                    if (i != h)
                    {
                        leftPosition = Random.value > 0.5 ? true : false;
                        position = leftPosition ?
                            lines[i].spawnPositions[0].position : lines[i].spawnPositions[1].position;
                        obj.GetComponent<EnemyMove>().leftDirection = !leftPosition;
                    }
                    else
                    {
                        leftPosition = !leftPosition;
                        position = leftPosition ?
                            lines[h].spawnPositions[0].position : lines[h].spawnPositions[1].position;
                        obj.GetComponent<EnemyMove>().leftDirection = !leftPosition;
                    }
                    obj.transform.position = position;
                    

                    //Debug.Log(enemiesOnLine);
                    if (lines[i].curve != null)
                    {
                        obj.GetComponent<EnemyMove>().mgCurve = lines[i].curve;
                    }
                    obj.GetComponent<EnemyMove>().MoveByCurve();
                    enemyCount++;
                }
            }
        }
    }


}
////сделать второй
//j = (int)Random.Range(0, pools.Length);
//if (!enemiesOnLine.Contains(j))
//{
//    enemiesOnLine.Add(j);
//    position = leftPosition ?
//                lines[h].spawnPositions[1].position : lines[h].spawnPositions[0].position;
//    obj = (GameObject)pools[j].Activate(position, Quaternion.identity);

//    obj.GetComponent<EnemyMove>().leftDirection = leftPosition;
//    enemyCount++;
//    if (lines[h].curve != null)
//    {
//        obj.GetComponent<EnemyMove>().mgcurves = lines[h].curve;
//    }
//}
