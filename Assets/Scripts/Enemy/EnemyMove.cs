using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    //static float speed;
    public bool leftDirection = true;
    public MGCurve mgcurves;
    public float duration;
    private float progress;

    //void Update()
    //{
    //    if (mgcurves != null)
    //        MoveByCurve();
    //    else
    //        moveStraight();
    //}

    void OnEnable()
    {
        progress = 0;
        //leftDirection = transform.position.x > 0.0f ? true : false;
    }

    void MoveByCurve()
    {
        progress += Time.deltaTime / duration;
        if ((progress > 1f)||(progress<0.0f))
        {
            progress = 0;
        }
        Vector3 position;
        if (leftDirection)
            position = mgcurves.GetPoint(progress);
        else
            position = mgcurves.GetPoint(1f-progress);
        transform.localPosition = position;

        //Vector3 dir = position + mgcurves.GetDirection(progress);
        //transform.LookAt (dir);
    }

    void MoveStraight()
    {
        //if (leftDirection)
        //    transform.Translate(Vector2.left * GameController.enemySpeed * Time.fixedDeltaTime);
        //else
        //    transform.Translate(Vector2.right * GameController.enemySpeed * Time.fixedDeltaTime);
        if (leftDirection)
            transform.Translate(((Vector3)ObjectControl.objectControl.rightPosition-transform.position).normalized * 
                GameController.enemySpeed * Time.fixedDeltaTime);
        else
            transform.Translate(((Vector3)ObjectControl.objectControl.leftPosition-transform.position).normalized *
                GameController.enemySpeed * Time.fixedDeltaTime);
    }
    void FixedUpdate()
    {
        if (mgcurves != null)
            MoveByCurve();
        else
            MoveStraight();
    }
}
