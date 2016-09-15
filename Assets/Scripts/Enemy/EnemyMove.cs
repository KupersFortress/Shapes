using UnityEngine;
using System;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    public bool leftDirection;
    public MGCurve mgCurve;
    public Vector3[] controlPoints;
    //public float speed;
    private float[] lengths;

    //IEnumerator Start()
    //{

    //    controlPoints = new Vector3[mgCurve.ControlPointCount];
    //    if (leftDirection)
    //    for (int i = 0; i < mgCurve.ControlPointCount; i++)
    //    {
    //        controlPoints[i] = mgCurve.GetControlPoint(i);
    //    }
    //    else
    //        for (int i = 0; i < mgCurve.ControlPointCount; i++)
    //        {
    //            controlPoints[i] = mgCurve.GetControlPoint(mgCurve.ControlPointCount - 1 - i);
    //        }

    //    controlPoints = mgCurve.Resolve(controlPoints, 100);
    //    // get our lengths
    //    GetLengths();
    //    var totalDistance = lengths[lengths.Length - 1];


    //    // now, lets do the moving
    //    float distance = 0; // the current distance
    //    int index = 0;
    //    while (distance <= totalDistance)
    //    {
    //        // get the indexed point
    //        IndexedPoint iPoint = GetPoint(distance, index);
    //        // update the transform and index
    //        transform.position = iPoint.point;
    //        index = iPoint.index;
    //        // wait until the next frame
    //        yield return null;
    //        // update the distance used.
    //        distance += GameController.enemySpeed * Time.deltaTime;
    //    }

    //}

    public void MoveByCurve()
    {
        StopCoroutine(MoveCoroutine());
        StartCoroutine(MoveCoroutine());
    }

    IEnumerator MoveCoroutine()
    {
        controlPoints = new Vector3[mgCurve.ControlPointCount];
        if (leftDirection)
            for (int i = 0; i < mgCurve.ControlPointCount; i++)
            {
                controlPoints[i] = mgCurve.GetControlPoint(i);
            }
        else
            for (int i = 0; i < mgCurve.ControlPointCount; i++)
            {
                controlPoints[i] = mgCurve.GetControlPoint(mgCurve.ControlPointCount - 1 - i);
            }

        controlPoints = mgCurve.Resolve(controlPoints, 100);
        // get our lengths
        GetLengths();
        var totalDistance = lengths[lengths.Length - 1];


        // now, lets do the moving
        float distance = 0; // the current distance
        int index = 0;
        while (distance <= totalDistance)
        {
            // get the indexed point
            IndexedPoint iPoint = GetPoint(distance, index);
            // update the transform and index
            transform.position = iPoint.point;
            index = iPoint.index;
            // wait until the next frame
            yield return null;
            // update the distance used.
            distance += GameController.enemySpeed * Time.deltaTime;
        }
    }
    void GetLengths()
    {
        // lets create lengths for each control point.
        lengths = new float[controlPoints.Length];
        float totalDistance = 0;
        //float last;
        float distance = 0;
        // go from the first, to the second to last
        for (var i = 0; i < controlPoints.Length - 1; i++)
        {
            // set the array value to the distance
            lengths[i] = totalDistance;
            // then get the next distance
            distance = Vector3.Distance(controlPoints[i], controlPoints[i + 1]);
            totalDistance += distance;
        }
        // set the last length
        lengths[lengths.Length - 1] = totalDistance;
    }

    IndexedPoint GetPoint(float distance, int index)
    {
        // get the total distance of the points.
        var totalDistance = lengths[lengths.Length - 1];

        // make sure that we are within the total distance of the points
        if (distance <= 0 || index < 0) return new IndexedPoint(controlPoints[0], 0);
        if (distance >= totalDistance ||
            index > controlPoints.Length - 1)
            return new IndexedPoint(controlPoints[controlPoints.Length - 1], controlPoints.Length - 1);

        // lets find the first point that is below the distance
        // but, who's next point is above the distance
        while (index < lengths.Length - 1 && lengths[index + 1] < distance)
            index++;

        // get the percentage of travel from the current length to the next
        // where the distance is.
        var amount = Mathf.InverseLerp(lengths[index], lengths[index + 1], distance);
        // we use that, to get the actual point
        return new IndexedPoint(
            Vector3.Lerp(controlPoints[index], controlPoints[index + 1], amount),
            index);
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
