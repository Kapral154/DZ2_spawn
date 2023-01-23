using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TargetPoint _targetPoint;
    [SerializeField] private GameObject _efectDestroy;

    private float _speed = 3f;
    public UnityAction<Enemy> Died;

    private void Start()
    {
        _targetPoint = FindObjectOfType<TargetPoint>();
    }

    private void Update()
    {
        if (_targetPoint != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPoint.transform.position, _speed * Time.deltaTime);
        }
        else
        {
            _targetPoint = GetComponent<TargetPoint>();
        }
    }

    public void Die()
    {
        Died?.Invoke(this);
        Instantiate(_efectDestroy, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
