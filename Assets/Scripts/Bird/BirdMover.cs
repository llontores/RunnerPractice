using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _stepSize;
    [SerializeField] private float _stepSpeed;
    private Vector3 _targetPosition;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;

    private void Start()
    {
        //_minHeight = transform.position.y + _stepSize;
        //_minHeight = transform.position.y - _stepSize;
        _targetPosition = transform.position;

    }


    private void Update()
    {
        if (transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _stepSpeed * Time.deltaTime);
    }

    public void TryMoveUp()
    {
        if (_targetPosition.y < _maxHeight)
            SetNextPosition(_stepSize);
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y > _minHeight)
            SetNextPosition(-_stepSize);
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + stepSize);
    }


}
