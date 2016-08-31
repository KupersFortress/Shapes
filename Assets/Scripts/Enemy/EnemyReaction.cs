using UnityEngine;
using System.Collections;

public class EnemyReaction : MonoBehaviour
{
    public Pool pool;

    void OnTriggerEnter2D(Collider2D other)
    {

        EnemySpawn.destroyedEnemyCount++;
        pool.Deactivate(gameObject);
        if (gameObject.tag!=other.gameObject.tag)
        {
            Hp.hpComponent.LoseHp();
        }
    }

    
}
