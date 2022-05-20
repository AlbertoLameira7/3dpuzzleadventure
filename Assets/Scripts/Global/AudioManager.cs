using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _background;
    [SerializeField] private StepsAudioSource _steps;

    void OnEnable()
    {
        PlayerManager.PlayStepsSound += PlayStepsSound;
    }

    void OnDisable()
    {
        PlayerManager.PlayStepsSound -= PlayStepsSound;
    }

    private void PlayStepsSound(Step _stepSound)
    {
        if (_stepSound == Step.LEFT)
        {
            _steps.PlayLeftStepSound();
        } else
        {
            _steps.PlayRightStepSound();
        }
    }
}
