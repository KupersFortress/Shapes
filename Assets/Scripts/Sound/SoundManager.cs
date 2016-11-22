using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    public SoundData data;
    AudioSource source;
    bool lostGame=false;

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
        if (!lostGame)
        {
            source.PlayOneShot(data.defeat);
            lostGame = true;
        }
    }
}
