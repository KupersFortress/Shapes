using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    //static float speed;
    bool leftDirection=true;

    
	
    void Start()
    {
        
    }
	void Update ()
    {
        leftDirection = transform.position.x > 0.0f ? true : false;
        if (leftDirection)
            transform.Translate(Vector2.left * GameController.enemySpeed * Time.deltaTime);
        else
            transform.Translate(Vector2.right * GameController.enemySpeed * Time.deltaTime);
        
    }

    
}
