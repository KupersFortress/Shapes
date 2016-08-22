using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    float speed;
    bool leftDirection=true;

	// Use this for initialization
	void Start ()
    {
        
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        leftDirection = transform.position.x > 0.0f ? true : false;
        if (leftDirection)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
