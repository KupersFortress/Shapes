using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour
{
    public MGCurve mgCurve;
    public bool reversed;

    [HideInInspector]
    public Transform spawnPosition;
    [HideInInspector]
    private float[] lengths;
    [HideInInspector]
    public Vector3[] controlPoints;
    [HideInInspector]
    public float totalDistance;

    void Awake()
    {
        controlPoints = new Vector3[mgCurve.ControlPointCount];
        if (reversed)
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
        totalDistance = lengths[lengths.Length - 1];
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

    public IndexedPoint GetPoint(float distance, int index)
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
