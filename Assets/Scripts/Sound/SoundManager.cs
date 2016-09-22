using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    public SoundData data;
    AudioSource source;

    void Start()
    {
        soundManager = this;
        source = GetComponent<AudioSource>();
        source.clip = data.background;
        source.Play();
    }
    
    public void LoseGame()
    {
        source.Stop();
        source.PlayOneShot(data.defeat);
    }
}
