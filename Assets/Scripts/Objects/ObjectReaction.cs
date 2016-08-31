using UnityEngine;
using System.Collections;

public class ObjectReaction : MonoBehaviour
{

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag != other.gameObject.tag)
        {
            StartCoroutine(Damage());
        }
    }

    IEnumerator Damage()
    {
        anim.SetBool("Damaged", true);
        yield return new WaitForSeconds(2.0f);
        anim.SetBool("Damaged", false);
    }

}
