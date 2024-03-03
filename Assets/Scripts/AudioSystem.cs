using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    static AudioSource source;

    void Awake() //tam kad atsirastu anksciau uz starta
    {
        source = GetComponent<AudioSource>();
    }

    public static void Play(AudioClip clip, float volume = 1f)
    {
        source.PlayOneShot(clip);
    }
}
