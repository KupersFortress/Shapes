using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn enemySpawn;
    [HideInInspector]
    public int destroyedEnemyCount;
    [SerializeField]
    float spawnDelay;
    //[SerializeField]
    int enemyCount;
    [SerializeField]
    int maxEnemyCount;
    public CurveComponent[] curves;
    public Pool[] pools;
    bool isSpawning;

    void Start()
    {
        enemySpawn = this;
        destroyedEnemyCount = 0;
        enemyCount = 0;
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

        List<int> EnemiesAtMoment = new List<int>();
        int j = (int)Random.Range(0, pools.Length);
        int h = (int)Random.Range(0, curves.Length);
        bool firstLine= Random.value > 0.5f ? true :false;
        Vector3 position = firstLine? curves[h].lines[0].controlPoints[0]:curves[h].lines[1].controlPoints[0];

        GameObject obj = (GameObject)pools[j].Activate(position, Quaternion.identity);
        obj.GetComponent<EnemyMove>().line = firstLine ? curves[h].lines[0] : curves[h].lines[1];
        obj.GetComponent<EnemyMove>().MoveByCurve();
        EnemiesAtMoment.Add(j);
        enemyCount++;

        for (int i = 0; i < curves.Length; i++)
        {
            if (Random.value > 0.2f)
            {
                int l = (int)Random.Range(0, pools.Length);

                if ((i != h) && (!EnemiesAtMoment.Contains(l)))
                {
                    firstLine = Random.value > 0.5f ? true : false;
                    position = firstLine ? curves[i].lines[0].controlPoints[0] : 
                        curves[i].lines[1].controlPoints[0];
                    EnemiesAtMoment.Add(l);
                    obj = pools[l].Activate(position, Quaternion.identity);

                    obj.GetComponent<EnemyMove>().line = firstLine ? curves[i].lines[0] : curves[i].lines[1];
                    obj.GetComponent<EnemyMove>().MoveByCurve();
                    enemyCount++;

                }
            }
        }

        
    }


}

