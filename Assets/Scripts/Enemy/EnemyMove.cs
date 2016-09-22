using UnityEngine;
using System;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    public Line line;
    
    public void MoveByCurve()
    {
        StopCoroutine(MoveCoroutine());
        StartCoroutine(MoveCoroutine());
    }

    IEnumerator MoveCoroutine()
    {

        // now, lets do the moving
        float distance = 0; // the current distance
        int index = 0;
        while (distance <= line.totalDistance)
        {
            // get the indexed point
            IndexedPoint iPoint = line.GetPoint(distance, index);
            // update the transform and index
            transform.position = iPoint.point;
            index = iPoint.index;
            // wait until the next frame
            yield return null;
            // update the distance used.
            distance += GameController.enemySpeed * Time.deltaTime;
        }
    }
    
}

// this is a helper class that lets us reduce cpu usage by storing the current index.
public class IndexedPoint
{
    public Vector3 point;
    public int index;

    public IndexedPoint(Vector3 point, int index)
    {
        this.point = point;
        this.index = index;
    }
}
