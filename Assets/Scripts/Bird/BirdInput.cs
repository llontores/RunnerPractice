using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
public class BirdInput : MonoBehaviour
{
    private BirdMover _mover;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
            _mover.TryMoveUp();

        if (Input.GetKeyDown(KeyCode.S))
            _mover.TryMoveDown();
    }
}
