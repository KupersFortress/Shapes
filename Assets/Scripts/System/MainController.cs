using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{

    public static MainController mainController;
    public int lvlCount;
    private string currentSceneName;
    private string nextSceneName;
    private AsyncOperation resourceUnloadTask;
    private AsyncOperation sceneLoadTask;
    private enum SceneState { Reset, Preload, Load, Unload, Postload, Ready, Run, Count };
    private SceneState sceneState;
    private delegate void UpdateDelegate();
    private UpdateDelegate[] updateDelegates;

   //int currentLevel;

    //bool testBool = true;

    protected void OnDestroy()
    {
        //Clean up all the updateDelegates
        if (updateDelegates != null)
        {
            for (int i = 0; i < (int)SceneState.Count; i++)
            {
                updateDelegates[i] = null;
            }
            updateDelegates = null;
        }

        //Clean up the singleton instance
        if (mainController != null)
        {
            mainController = null;
        }
    }

    void Awake()
    {
        //if (mainController == null)
            mainController = this;
        //else
        //    Destroy(gameObject);

        //currentLevel = SceneManager.GetActiveScene().buildIndex;
        DontDestroyOnLoad(gameObject);
        updateDelegates = new UpdateDelegate[(int)SceneState.Count];
        //Set each updateDelegate
        updateDelegates[(int)SceneState.Reset] = UpdateSceneReset;
        updateDelegates[(int)SceneState.Preload] = UpdateScenePreload;
        updateDelegates[(int)SceneState.Load] = UpdateSceneLoad;
        updateDelegates[(int)SceneState.Unload] = UpdateSceneUnload;
        updateDelegates[(int)SceneState.Postload] = UpdateScenePostload;
        updateDelegates[(int)SceneState.Ready] = UpdateSceneReady;
        updateDelegates[(int)SceneState.Run] = UpdateSceneRun;

        nextSceneName = "MainMenu";
        sceneState = SceneState.Reset;

    }

    public static void SwitchScene(string nextSceneName)
    {
        if (mainController != null)
        {
            if (mainController.currentSceneName != nextSceneName)
            {
                mainController.nextSceneName = nextSceneName;
            }
        }
    }

    public void NextLevel()
    {
        //string[] level = currentSceneName.Split('_');
        //string sceneName = SceneManager.GetActiveScene().name;
        string[] level = SceneManager.GetActiveScene().name.Split('_');
        int result;
        bool lvlvExist = int.TryParse(level[1], out result);
        result++;
        if ((lvlvExist)&&(result <= lvlCount))
            SwitchScene(level[0]+'_'+result.ToString());
    }

    protected void Update()
    {
        //Debug.Log(SceneManager.GetActiveScene().name);
        if (updateDelegates[(int)sceneState] != null)
        {
            updateDelegates[(int)sceneState]();
        }
    }

    public static void LoseGame()
    {
        SceneManager.LoadScene(0);
    }

    private void UpdateSceneReset()
    {
        // run a gc pass
        System.GC.Collect();
        sceneState = SceneState.Preload;
    }

    // handle anything that needs to happen before loading
    private void UpdateScenePreload()
    {
        sceneLoadTask = SceneManager.LoadSceneAsync(nextSceneName);
        sceneState = SceneState.Load;
    }

    // show the loading screen until it's loaded
    private void UpdateSceneLoad()
    {
        // done loading?
        if (sceneLoadTask.isDone == true)
        {
            sceneState = SceneState.Unload;
        }
        else
        {
            // update scene loading progress
        }
    }

    // clean up unused resources by unloading them
    private void UpdateSceneUnload()
    {
        // cleaning up resources yet?
        //if (resourceUnloadTask == null)
        //{
            //resourceUnloadTask = Resources.UnloadUnusedAssets();
        //}
        //else
        //{
            // done cleaning up?
            //if (resourceUnloadTask.isDone == true)
            //{
                //resourceUnloadTask = null;
                sceneState = SceneState.Postload;
            //}
        //}
    }

    // handle anything that needs to happen immediately after loading
    private void UpdateScenePostload()
    {
        currentSceneName = nextSceneName;
        sceneState = SceneState.Ready;
    }

    // handle anything that needs to happen immediately before running
    private void UpdateSceneReady()
    {
        // run a gc pass
        // if you have assets loaded in the scene that are
        // currently unused currently but may be used later
        // DON'T do this here
        //System.GC.Collect();
        sceneState = SceneState.Run;
    }

    // wait for scene change
    private void UpdateSceneRun()
    {
        if (currentSceneName != nextSceneName)
        {
            sceneState = SceneState.Reset;
        }
    }

}
