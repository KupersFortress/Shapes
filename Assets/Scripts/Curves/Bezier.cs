using UnityEngine;
using System.Collections;

public class Bezier : MonoBehaviour
{
        //public static Vector3[] Resolve(Vector3[] controlPoints, int numPoints)
        //{
        //    if (controlPoints.Length < 2)
        //    {
        //        return controlPoints;
        //    }

        //    Vector3[] result = new Vector3[numPoints];

        //    for (var i = 0; i < numPoints; i++)
        //    {
        //        float t = (float)i / (float)(numPoints - 1);
        //        result[i] = GetBezierPoint(t, controlPoints, 0, controlPoints.Length);
        //    }

        //    return result;
        //}
    //добавлено
    
    //


    //static Vector3 GetBezierPoint(float t, Vector3[] controlPoints, int index, int count)
    //{
    //    if (count == 1) return controlPoints[index];
    //    var a = GetBezierPoint(t, controlPoints, index, count - 1);
    //    var b = GetBezierPoint(t, controlPoints, index + 1, count - 1);
    //    return Vector3.Lerp(a, b, t);
    //}
}

