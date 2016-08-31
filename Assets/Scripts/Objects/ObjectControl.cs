using UnityEngine;
using System.Collections;

public class ObjectControl : MonoBehaviour
{
    public GameObject redObject;
    public GameObject blueObject;

    //float leftPosition;
    //float rightPosition;
    Vector2 redBasePosition;
    Vector2 blueBasePosition;
    bool isMoving;
    bool blueMoveRight;


    void Start()
    {
        blueMoveRight = true;
        redBasePosition = redObject.transform.position;
        blueBasePosition = blueObject.transform.position;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch myTouch;
            myTouch = Input.GetTouch(0);
            if (myTouch.phase==TouchPhase.Began)
            {
                isMoving = true;
                blueMoveRight=!blueMoveRight;
            }
        }
        if (isMoving)
        {
            ChangePositions();
        }
    }

    void ChangePositions()
    {
        //двигаем синий объект
        if (blueMoveRight)
        {
            Vector2 x = Vector2.Lerp(blueObject.transform.position, blueBasePosition, 0.2f);
            blueObject.transform.position = x;
            redObject.transform.position = -x;
            if ((x-blueBasePosition).magnitude < 0.1f)
                isMoving = false;
        }
        else
        {
            Vector2 x = Vector2.Lerp(blueObject.transform.position, redBasePosition, 0.2f);
            blueObject.transform.position = x;
            redObject.transform.position = -x;
            if ((x - redBasePosition).magnitude < 0.1f)
                isMoving = false;
        }

        //if (blueMoveRight)
        //{
        //    float x = Mathf.Lerp(blueObject.transform.position.x, rightPosition, 0.2f);
        //    blueObject.transform.position = new Vector2(x, transform.position.y);
        //    redObject.transform.position = new Vector2(-x, transform.position.y);
        //    if (Mathf.Abs(x - rightPosition) < 0.01f)
        //        isMoving = false;
        //}
        //else
        //{
        //    float x = Mathf.Lerp(blueObject.transform.position.x, leftPosition, 0.2f);
        //    blueObject.transform.position = new Vector2(x, transform.position.y);
        //    redObject.transform.position = new Vector2(-x, transform.position.y);
        //    if (Mathf.Abs(x - leftPosition) < 0.01f)
        //        isMoving = false;
        //}

     
    }
}
