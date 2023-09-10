using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _placesPoints;

    private Transform[] _places;
    private int _currentPlaceIndex;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
        _places = new Transform[_placesPoints.childCount];

        for (int i = 0; i < _placesPoints.childCount; i++)
            _places[i] = _placesPoints.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform currentPoint = _places[_currentPlaceIndex];

        transform.position = Vector3.MoveTowards(_startPosition, currentPoint.position, _speed * Time.deltaTime);


        if (transform.position == currentPoint.position) 
            SetNextPlace();
    }

    private void SetNextPlace()
    {
        _currentPlaceIndex++;

        if (_currentPlaceIndex == _places.Length)
            _currentPlaceIndex = 0;

        Vector3 currentPointPosition = _places[_currentPlaceIndex].transform.position;
        transform.forward = currentPointPosition - transform.position;
    }
}