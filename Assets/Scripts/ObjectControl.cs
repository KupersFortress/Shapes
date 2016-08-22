using UnityEngine;
using System.Collections;

public class ObjectControl : MonoBehaviour
{
    public GameObject redObject;
    public GameObject blueObject;

    float newRedPosition;
    float newBluePosition;
    bool isMoving;

    void Update()
    {
        if ((Input.touchCount > 0)&&(!isMoving))
        {
            Touch myTouch;
            myTouch = Input.GetTouch(0);
            if (myTouch.phase==TouchPhase.Began)
            {
                isMoving = true;
                newBluePosition = -blueObject.transform.position.x;
            }
        }
        if (isMoving)
        {
            ChangePositions();
        }
    }

    void ChangePositions()
    {
        float x = Mathf.Lerp(blueObject.transform.position.x, newBluePosition, 0.1f);
        blueObject.transform.position = new Vector2(x,transform.position.y);
        redObject.transform.position = new Vector2(-x, transform.position.y);
        if (Mathf.Abs(x - newBluePosition) < 0.01f)
            isMoving = false;
    }
}
