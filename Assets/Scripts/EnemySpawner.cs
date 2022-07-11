using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private float _timeBetweeòSpawn;

    private Transform[] _points;
    private float _timeToSpawn;
    private int _numberOfSpawn;
    

    public void Start()
    {
        _timeToSpawn = _timeBetweeòSpawn;
        _points = new Transform[_spawnPoints.childCount];
        _numberOfSpawn = 0;

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }
    }

    public void Update()
    {
        if (_timeToSpawn <= 0)
        {
            Instantiate(_enemy, _points[_numberOfSpawn].position, Quaternion.identity);
            _timeToSpawn = _timeBetweeòSpawn;
            _numberOfSpawn++;

            if (_numberOfSpawn == _points.Length)
            {
                _numberOfSpawn = 0;
            }
        }
        else
        {
            _timeToSpawn -= Time.deltaTime;
        }
    }
}
