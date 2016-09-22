using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
    [SerializeField]
    float baseEnemySpeed;
    public static float enemySpeed;
    int currentLevel;
    bool testBool = true;

    void Awake()
    {
        gameController = this;
        enemySpeed = baseEnemySpeed;
    }

    void Update()
    {
        //TestFunction();
    }
    


    //void TestFunction()
    //{
    //    if (testBool)
    //    {
    //        if (Time.time > 15.0f)
    //        {
    //            enemySpeed *= 1.5f;
    //            testBool = false;
    //        }
    //    }
    //}

    
}
