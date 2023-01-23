using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _pointSpawn;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _maxCountEnemy;

    private Coroutine _spawnCorutine;
    private int _currentCountEnemy;
    private List<Enemy> _enemis = new List<Enemy>();

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
        while (true)
        {
            if (_currentCountEnemy != _maxCountEnemy)
            {
                Transform spawnPoint = _pointSpawn[Random.Range(0, _pointSpawn.Length - 1)];
                Enemy enemy = Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
                _enemis.Add(enemy);
                enemy.Died += OnDied;
                _currentCountEnemy++;
                yield return new WaitForSeconds(2f);
            }

            yield return null;
        }
    }
}

