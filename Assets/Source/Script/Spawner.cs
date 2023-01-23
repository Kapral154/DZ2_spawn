using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _pointSpawn;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _maxCountEnemy;

    WaitForSeconds _spawnDelay = new WaitForSeconds(2f);

    private Coroutine _spawnCorutine;
    private List<Enemy> _enemis = new List<Enemy>();
    private int _currentCountEnemy;

    private void Start()
    {
        _spawnCorutine = StartCoroutine(Spawn());
    }

    private void OnDied(Enemy enemy)
    {
        enemy.Died -= OnDied;
        _currentCountEnemy--;
        _enemis.Remove(enemy);
    }

    private IEnumerator Spawn()
    {
        while (_currentCountEnemy != _maxCountEnemy)
        {           
            Transform spawnPoint = _pointSpawn[Random.Range(0, _pointSpawn.Length - 1)];
            Enemy enemy = Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
            _enemis.Add(enemy);
            enemy.Died += OnDied;
            _currentCountEnemy++;

            yield return _spawnDelay;
        }
    }
}

