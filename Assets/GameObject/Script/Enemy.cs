using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _pointPlayer;
    [SerializeField] private GameObject _efectDestroy;
    
    private float _speed = 3f;

    public UnityAction<Enemy> Died;

    private void Start()
    {
        _pointPlayer = GameObject.FindObjectOfType<TargetPoint>().transform;
    }

    private void Update()
    {
        if (_pointPlayer != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointPlayer.position, _speed * Time.deltaTime);            
        }
        else
        {
            var target = GameObject.FindObjectOfType<TargetPoint>().transform;
            _pointPlayer.position = target.position;
        }
    }

    public void Die()
    {
        Died?.Invoke(this);
        Instantiate(_efectDestroy, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
