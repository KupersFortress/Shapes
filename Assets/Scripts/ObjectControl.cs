using UnityEngine;
using System.Collections;

public class ObjectControl : MonoBehaviour
{
    public GameObject redObject;
    public GameObject blueObject;

    float leftPosition;
    float rightPosition;
    bool isMoving;
    bool blueMoveRight;


    void Start()
    {
        blueMoveRight = true;
        leftPosition = redObject.transform.position.x;
        rightPosition = blueObject.transform.position.x;
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
            float x = Mathf.Lerp(blueObject.transform.position.x, rightPosition, 0.1f);
            blueObject.transform.position = new Vector2(x, transform.position.y);
            redObject.transform.position = new Vector2(-x, transform.position.y);
            if (Mathf.Abs(x - rightPosition) < 0.01f)
                isMoving = false;
        }
        else
        {
            float x = Mathf.Lerp(blueObject.transform.position.x, leftPosition, 0.1f);
            blueObject.transform.position = new Vector2(x, transform.position.y);
            redObject.transform.position = new Vector2(-x, transform.position.y);
            if (Mathf.Abs(x - leftPosition) < 0.01f)
                isMoving = false;
        }

        //float x = Mathf.Lerp(blueObject.transform.position.x, newBluePosition, 0.1f);
        //blueObject.transform.position = new Vector2(x,transform.position.y);
        //redObject.transform.position = new Vector2(-x, transform.position.y);
        //if (Mathf.Abs(x - newBluePosition) < 0.01f)
        //    isMoving = false;
    }
}
