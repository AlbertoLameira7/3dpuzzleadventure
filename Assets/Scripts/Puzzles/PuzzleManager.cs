using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private IPuzzleState _currentPuzzle;

    // Start is called before the first frame update
    void Start()
    {
        // start first puzzle
        _currentPuzzle = new Puzzle_One();
        _currentPuzzle.OnEnter();
    }

    void Update() {
        _currentPuzzle.OnUpdate();
    }

    public bool ChangePuzzle() {
        return true;
    }
}
