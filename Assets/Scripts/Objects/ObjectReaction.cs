using UnityEngine;
using System.Collections;

public class ObjectReaction : MonoBehaviour
{
    public SoundData soundData;
    AudioSource audioSource;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if ((gameObject.tag != other.gameObject.tag)&&(other.gameObject.layer!=gameObject.layer)&&(!ObjectInfo.invincible))
        {
            //Debug.Log("sdfg");
            audioSource.PlayOneShot(soundData.damage);
            Hp.hpComponent.LoseHp();
            ObjectInfo.objectInfo.MakeInvincible();
            ObjectInfo.objectInfo.GetDamage();
            //StartCoroutine(Damage());
        }
        else
        {
            audioSource.PlayOneShot(soundData.enemyDestroy);
        }
    }



}
