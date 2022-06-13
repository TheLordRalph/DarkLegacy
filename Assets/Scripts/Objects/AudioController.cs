using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying && SceneManager.GetActiveScene().name != "SampleScene") return;
        if (_audioSource.isPlaying && SceneManager.GetActiveScene().name == "SampleScene")
        {
            _audioSource.Stop();
            _audioSource.Play();
        };
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
