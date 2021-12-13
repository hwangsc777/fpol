using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioClips { spawn0, spawn1, shoot, hit };

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public AudioSource spawnSource;
    public AudioSource shootSource;
    public AudioSource hitSource;

    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySource(AudioClips clip)
    {
        switch (clip)
        {
            case AudioClips.spawn0:
                spawnSource.clip = audioClips[(int)clip];
                spawnSource.Play();
                break;
            case AudioClips.spawn1:
                spawnSource.clip = audioClips[(int)clip];
                spawnSource.Play();
                break;
            case AudioClips.shoot:
                shootSource.clip = audioClips[(int)clip];
                shootSource.Play();
                break;
            case AudioClips.hit:
                hitSource.clip = audioClips[(int)clip];
                hitSource.Play();
                break;
            default:
                break;
        }
    }
}
