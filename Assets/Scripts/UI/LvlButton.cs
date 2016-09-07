using UnityEngine;
using System.Collections;

public class LvlButton : MonoBehaviour
{
    public string lvlName;
	
    public void SwitchScene()
    {
        MainController.SwitchScene(lvlName);
    }
}
