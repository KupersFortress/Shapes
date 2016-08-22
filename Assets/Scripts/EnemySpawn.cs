using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    float spawnDelay;
    public Pool[] pools;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Spawn());
	}
	
	IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            int i=(int)Random.Range(0, pools.Length);
            float side = Random.value > 0.5 ? Edges.leftEdge : Edges.rightEdge;
            pools[i].Activate(new Vector2(side, 0.0f), Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
