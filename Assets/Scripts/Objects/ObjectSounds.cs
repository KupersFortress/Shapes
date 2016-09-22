using UnityEngine;
using System.Collections;

public class ObjectSounds : MonoBehaviour
{
    public SoundData soundData;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void DestroyEnemy()
    {
        //audioSource.clip = soundData.enemyDestroy;
        audioSource.PlayOneShot(soundData.enemyDestroy);
    }

}
