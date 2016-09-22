using UnityEngine;
using System.Collections;

public class PaintCurve : MonoBehaviour
{
    LineRenderer lineRenderer;
    public Line line;


	void Start ()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPositions(line.controlPoints);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
