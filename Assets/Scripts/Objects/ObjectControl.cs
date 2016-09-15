using UnityEngine;
using System.Collections;

public class ObjectControl : MonoBehaviour
{
    public static ObjectControl objectControl;
    public GameObject redObject;
    public GameObject blueObject;

    //float leftPosition;
    //float rightPosition;
    public Vector2 leftPosition;
    public Vector2 rightPosition;
    bool isMoving;
    bool blueMoveRight;

    void Awake()
    {
        objectControl = this;
    }

    void Start()
    {
        blueMoveRight = true;
        leftPosition = redObject.transform.position;
        rightPosition = blueObject.transform.position;
    }

    void Update()
    {
        //убрать потом
        if (Input.GetMouseButtonDown(0))
        {
                isMoving = true;
                blueMoveRight = !blueMoveRight;
        }

        if (!(Input.GetMouseButtonDown(0))&&Input.touchCount > 0)
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
            Vector2 x = Vector2.Lerp(blueObject.transform.position, rightPosition, 0.2f);
            blueObject.transform.position = x;
            redObject.transform.position = -x;
            if ((x-rightPosition).magnitude < 0.1f)
                isMoving = false;
        }
        else
        {
            Vector2 x = Vector2.Lerp(blueObject.transform.position, leftPosition, 0.2f);
            blueObject.transform.position = x;
            redObject.transform.position = -x;
            if ((x - leftPosition).magnitude < 0.1f)
                isMoving = false;
        }


     
    }
}
