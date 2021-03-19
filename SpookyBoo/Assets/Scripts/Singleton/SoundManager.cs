using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    private Dictionary<string, AudioClip> _clips;

    public AudioSource bgmAudioSource;
    public AudioSource sfxAudioSource;

    protected override void OnAwake()
    {
        base.OnAwake();

        _clips = new Dictionary<string, AudioClip>();

        AudioClip[] loadedClips = Resources.LoadAll<AudioClip>("Audios");
        int clipsLen = loadedClips.Length;

        for(int i = 0; i < clipsLen; i++)
        {
            string clipName = loadedClips[i].name;

            if (_clips.ContainsKey(clipName))
            {
                _clips.Add(clipName, loadedClips[i]);
            }
        }
    }

    public void PlaySFX(string clipName, float volume)
    {
        if (_clips.ContainsKey(clipName) == false)
            return;

        sfxAudioSource.clip = _clips[clipName];
        sfxAudioSource.volume = volume;

        sfxAudioSource.Play();
    }

    public void PlayBGM(string clipName, float volume)
    {
        if (_clips.ContainsKey(clipName) == false)
            return;

        bgmAudioSource.clip = _clips[clipName];
        bgmAudioSource.volume = volume;

        bgmAudioSource.Play();
    }
}
