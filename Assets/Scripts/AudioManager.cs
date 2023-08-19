using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;



[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;

    AudioSource _audioSource;


    private void Awake()
    {
        #region Singleton Pattern (Simple)
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);

            _audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
    }
    public void PlaySong(AudioClip clip)
    {
        _audioSource.clip = clip;

        _audioSource.volume = 0.1f;

        _audioSource.Play();
    }
}


