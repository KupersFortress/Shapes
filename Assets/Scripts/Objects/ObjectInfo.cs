using UnityEngine;
using System.Collections;

public class ObjectInfo : MonoBehaviour
{
    public static bool invincible;
    public static ObjectInfo objectInfo;
    public Animator redAnim;
    public Animator blueAnim;

    void Awake()
    {
        objectInfo = this;
        invincible = false;
    }

    public void MakeInvincible()
    {
        StopCoroutine(MakeInvincibleCoroutine());
        StartCoroutine(MakeInvincibleCoroutine());
    }

    public void GetDamage()
    {
        StopCoroutine(Damage());
        StartCoroutine(Damage());
    }

    IEnumerator MakeInvincibleCoroutine()
    {
        invincible = true;
        yield return new WaitForSeconds(2.0f);
        invincible = false;
    }

    IEnumerator Damage()
    {
        blueAnim.SetBool("Damaged", true);
        redAnim.SetBool("Damaged", true);
        yield return new WaitForSeconds(2.0f);
        blueAnim.SetBool("Damaged", false);
        redAnim.SetBool("Damaged", false);
    }

}
