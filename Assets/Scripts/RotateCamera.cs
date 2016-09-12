using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour
{
    public float speed;
	
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, speed*Time.deltaTime));
    }
}
