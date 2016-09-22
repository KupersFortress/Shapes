using UnityEngine;
using System.Collections;

public class ObjectInfo : MonoBehaviour
{
    public static bool invincible;
    public static ObjectInfo objectInfo;

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

    IEnumerator MakeInvincibleCoroutine()
    {
        invincible = true;
        yield return new WaitForSeconds(2.0f);
        invincible = false;
    }
	
}
