using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    private float _lifeTime = 2f;
    private float _speed = 10;

    private void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);        
        if (_lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            _lifeTime -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.Die();
            Destroy(gameObject);
        }
    }
}
