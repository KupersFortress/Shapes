using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour
{
    public enum ActionType { IncreaseSpeed, DecreaseSpeed };
    public ActionType actionType;
    public float by;
    public float after;

    public void Start()
    {
        switch (actionType)
        {
            case ActionType.IncreaseSpeed:
                {
                    StartCoroutine(IncreaseSpeed());
                }
                break;
            case ActionType.DecreaseSpeed:
                {
                    StartCoroutine(DecreaseSpeed());
                }
                break;
        }
    }

        IEnumerator IncreaseSpeed()
        {
        yield return new WaitForSeconds(after);
        GameController.enemySpeed += by;
        yield return null;
    }
    

    IEnumerator DecreaseSpeed()
    {
        yield return new WaitForSeconds(after);
        GameController.enemySpeed -= by;
        yield return null;
    }
}
