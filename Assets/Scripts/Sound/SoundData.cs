using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "SoundData", menuName = "Sound", order = 1)]
public class SoundData : ScriptableObject
{
    public AudioClip background;
    public AudioClip damage;
    public AudioClip enemyDestroy;
    public AudioClip defeat;
}
