using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Step
{
    LEFT,
    RIGHT
}

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private InputManager _inputManager;
    private (float x, float y) _moveSpeed;
    private float _playerSpeed;
    private Step _nextStep = Step.RIGHT;
    private bool isStepSoundPlaying = false;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _playerSpeed = _player.GetComponent<MovementController>().GetPlayerSpeed();
    }

    private void Update()
    {
        _inputManager.HandleInput();
        //Debug.Log("This is nr of items in inventory: " + InventoryManager.GetNrItems());
    }

    private void FixedUpdate()
    {
        _moveSpeed = _inputManager.HandleMovementInput();

        if (_moveSpeed.x != 0 || _moveSpeed.y != 0)
        {
            //call sounds
            Debug.Log("moving from PlayerManager");
            StartCoroutine(StepSound(_playerSpeed / 1000 + 0.4f));
        }
    }

    private void ToggleStep()
    {
        _nextStep = _nextStep == Step.LEFT ? Step.RIGHT : Step.LEFT;
    }

    IEnumerator StepSound(float time)
    {
        if (isStepSoundPlaying)
            yield break;

        isStepSoundPlaying = true;

        Debug.Log("STEP: " + _nextStep);

        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        ToggleStep();

        isStepSoundPlaying = false;
    }
}
