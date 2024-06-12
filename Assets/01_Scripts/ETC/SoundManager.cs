using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _bgmAudioSource;
    [SerializeField] private AudioSource _sfxAudioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Clear()
    {
        _bgmAudioSource.clip = null;
        _bgmAudioSource.Stop();
        _sfxAudioSource.clip = null;
        _sfxAudioSource.Stop();
    }

    public void SoundPlay(AudioClip audioClip, SoundType soundType = SoundType.SFX)
    {
        if (audioClip == null) return;

        if (soundType == SoundType.BGM)
        {
            if (_bgmAudioSource.isPlaying) _bgmAudioSource.Stop();
            _bgmAudioSource.clip = audioClip;
            _bgmAudioSource.Play();
        }
        else if (soundType == SoundType.SFX)
        {
            _sfxAudioSource.PlayOneShot(audioClip);
        }
    }
}

public enum SoundType
{
    BGM,
    SFX
}
