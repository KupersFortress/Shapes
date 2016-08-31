using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour
{
    public static int destroyedEnemyCount;
    [SerializeField]
    float spawnDelay;
    [SerializeField]
    int enemyCount;
    [SerializeField]
    int maxEnemyCount;
    public Line[] lines;
    public Pool[] pools;
    bool isSpawning;
    
    int enemyTypeCount;


    void Start()
    {
        enemyTypeCount = pools.Length;
        StartCoroutine(Spawn());
        enemyCount = 0;
        isSpawning = true;

    }

    void Update()
    {
        if (destroyedEnemyCount == maxEnemyCount)
            GameController.gameController.ChangeLevel();
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
                yield return new WaitForSeconds(spawnDelay + Random.value);
            }

        }
    }

    void GenerateMultipleEnemies()
    {
        List<int> enemiesOnLine = new List<int>();
        int j = (int)Random.Range(0, pools.Length);
        enemiesOnLine.Add(j);

        int h = (int)Random.Range(0, lines.Length);
        Vector3 position = Random.value > 0.5 ?
                        lines[h].spawnPositions[0].position : lines[h].spawnPositions[1].position;
        pools[j].Activate(position, Quaternion.identity);
        enemyCount++;

        for (int i = 0; i < lines.Length-1; i++)
        {
            if ((i!=h) && (Random.value > 0.5f))
            {
                h = (int)Random.Range(0, pools.Length);
                if (!enemiesOnLine.Contains(h))
                {
                    position = Random.value > 0.5 ?
                        lines[i].spawnPositions[0].position : lines[i].spawnPositions[1].position;
                    pools[h].Activate(position, Quaternion.identity);
                    enemyCount++;
                }

                
            }
        }
    }


}

//public class EnemySpawn : MonoBehaviour
//{
//    public static int destroyedEnemyCount;
//    [SerializeField]
//    float spawnDelay;
//    [SerializeField]
//    int enemyCount;
//    [SerializeField]
//    int maxEnemyCount;
//    public Transform spawnPositionObject;
//    public Transform[] spawnPositions;
//    public Pool[] pools;
//    bool isSpawning;
//    int spawnPositionCount;
//    int enemyTypeCount;


//	void Start ()
//    {
//        enemyTypeCount = pools.Length;
//        spawnPositionCount = spawnPositionObject.transform.childCount;
//        spawnPositions = new Transform[spawnPositionCount];
//        for (int i=0;i< spawnPositionCount; i++)
//        {
//            spawnPositions[i] = spawnPositionObject.transform.GetChild(i);
//        }
//        StartCoroutine(Spawn());
//        enemyCount = 0;
//        isSpawning = true;

//    }

//    void Update()
//    {
//        if (destroyedEnemyCount == maxEnemyCount)
//            GameController.gameController.ChangeLevel();
//    }

//    IEnumerator Spawn()
//    {
//        yield return new WaitForSeconds(1.0f);
//        while (isSpawning)
//        {
//            if (enemyCount >= maxEnemyCount)
//            {
//                isSpawning = false;
//                yield return null;
//            }
//            else
//            {
//                int i = (int)Random.Range(0, pools.Length);
//                Vector3 position = Random.value > 0.5 ?
//                    spawnPositions[0].position : spawnPositions[1].position;
//                pools[i].Activate(position, Quaternion.identity);
//                enemyCount++;

//                yield return new WaitForSeconds(spawnDelay + Random.value);
//            }

//        }
//    }

//    void GenerateMultipleEnemies()
//    {
//        int[] lines = new int[spawnPositionCount / 2];
//        for (int i = 0; i < spawnPositionCount/2; i++)
//        {

//        }
//    }

//    //IEnumerator Spawn()
//    //   {
//    //       yield return new WaitForSeconds(1.0f);
//    //       while (isSpawning)
//    //       {
//    //           if (enemyCount >= maxEnemyCount)
//    //           {
//    //               isSpawning = false;
//    //               yield return null;
//    //           }
//    //           else
//    //           {
//    //               int i = (int)Random.Range(0, pools.Length);
//    //               Vector3 position = Random.value > 0.5 ?
//    //                   spawnPositions[0].position : spawnPositions[1].position;
//    //               pools[i].Activate(position, Quaternion.identity);
//    //               enemyCount++;

//    //               yield return new WaitForSeconds(spawnDelay + Random.value);
//    //           }

//    //       }


//    //   }
//}
