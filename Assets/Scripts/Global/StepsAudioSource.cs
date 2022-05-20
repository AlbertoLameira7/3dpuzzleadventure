using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsAudioSource : MonoBehaviour
{
    [SerializeField] private AudioClip _leftStepSound;
    [SerializeField] private AudioClip _rightStepSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayLeftStepSound()
    {
        _audioSource.clip = _leftStepSound;
        RandomizeAudioSourcePitch();
        _audioSource.Play();
    }
    public void PlayRightStepSound()
    {
        _audioSource.clip = _rightStepSound;
        RandomizeAudioSourcePitch();
        _audioSource.Play();
    }

    private void RandomizeAudioSourcePitch()
    {
        _audioSource.pitch = Random.Range(0.82f, 1.25f);
    }
}
