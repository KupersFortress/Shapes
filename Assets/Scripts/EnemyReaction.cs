using UnityEngine;
using System.Collections;

public class EnemyReaction : MonoBehaviour
{
    public Pool pool;

    void Awake()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        pool.Deactivate(gameObject);
    }
}
