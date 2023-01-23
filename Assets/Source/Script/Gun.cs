using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bulet _bulet;
    [SerializeField] private Transform[] _shotPoints;
    [SerializeField] private GameObject _efect;

    private float _reload = 0.2f;
    private float _startReload;
    private int _shotPoint = 1;

    void Start()
    {
        _startReload = _reload;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 differnce111 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotor111 = Mathf.Atan2(differnce111.y, differnce111.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotor111 - 90f);

        if (_reload <= 0) 
        {
            if (Input.GetMouseButton(0))
            {
                if (_shotPoint == 0)
                {
                    Instantiate(_bulet, _shotPoints[0].position, _shotPoints[0].rotation);
                    Instantiate(_efect, _shotPoints[0].position, _shotPoints[0].rotation);
                    _shotPoint = 1;
                }
                else
                {
                    Instantiate(_bulet, _shotPoints[1].position, _shotPoints[1].rotation);
                    Instantiate(_efect, _shotPoints[1].position, _shotPoints[1].rotation);
                    _shotPoint = 0;
                }
                
                _reload = _startReload;
            }
        }
        else if(_reload > 0)
        {
            _reload -= Time.deltaTime;
        }
    }
}
