using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
    [SerializeField]
    float baseEnemySpeed;
    public static float enemySpeed;
    private string currentSceneName;
    private string nextSceneName;
    private AsyncOperation resourceUnloadTask;
    private AsyncOperation sceneLoadTask;
    private enum SceneState { FirstPart,SecondPart, Count };
    private SceneState sceneState;
    private delegate void UpdateDelegate();
    private UpdateDelegate[] updateDelegates;

    int currentLevel;

    bool testBool = true;

    void Awake()
    {
        gameController = this;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        DontDestroyOnLoad(gameObject);
        updateDelegates = new UpdateDelegate[(int)SceneState.Count];

        //Set each updateDelegate
       //updateDelegates[(int)SceneState.Reset] = UpdateSceneReset;
        //updateDelegates[(int)SceneState.Preload] = UpdateScenePreload;

    }

    void Update()
    {
        TestFunction();
    }
    
    void Start()
    {
        enemySpeed = baseEnemySpeed;
    }

    void  FirstPart()
    {

    }

    void SecondPart()
    {

    }

    public static void LoseGame()
    {
        SceneManager.LoadScene(0);
    }

    void TestFunction()
    {
        if (testBool)
        {
            if (Time.time > 15.0f)
            {
                enemySpeed *= 1.5f;
                testBool = false;
            }
        }
    }

    public void ChangeLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
            SceneManager.LoadScene(1);
        //else
        //    SceneManager.LoadScene(0);
    }
}
