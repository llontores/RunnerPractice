using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _delayInSeconds;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _maxRandom;
    [SerializeField] private List<int> _numbersToHeal = new List<int>();
    [SerializeField] private GameObject _healPrefab;

    private float _elapsedTime;

    private void Start()
    {
        Initialize(_enemy);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        
        if(_elapsedTime >= _delayInSeconds)
        {
            int randomChoice = Random.Range(0, _maxRandom);
            int spawnPointIndex = Random.Range(0, _spawnPoints.Length);

            if (_numbersToHeal.Contains(randomChoice) == true)
            {
                Instantiate(_healPrefab, _spawnPoints[spawnPointIndex].position , Quaternion.identity);
            }
            else if (_numbersToHeal.Contains(randomChoice) == false)
            {
                if (TryGetObject(out GameObject enemy))
                {
                    _elapsedTime = 0;
                    SetEnemy(enemy, _spawnPoints[spawnPointIndex].position);
                }
            }            
        }
    }

    private void SetEnemy(GameObject enemy,Vector3 spawnpoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnpoint;
    }
}
