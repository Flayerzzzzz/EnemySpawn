using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private float _timeBetweenSpawn;

    private Transform[] _points;
    

    public void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }

        StartCoroutine(EnemySpawn());
    }

    private IEnumerator EnemySpawn()
    {
        for (int i = 0; i <= _points.Length; i++)
        {
            Instantiate(_enemy, _points[i].position, Quaternion.identity);

            if (i == _points.Length - 1)
            {
                i = -1;
            }
            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }
}
