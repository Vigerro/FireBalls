using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private float _shotPeriod;
    [SerializeField] private float _recoilDistance;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if(_timer >= _shotPeriod)
            {
                Shot();
                transform.DOMoveZ(transform.position.z + _recoilDistance, _shotPeriod / 2).SetLoops(2, LoopType.Yoyo);
                _timer = 0f;
            }   
        }
    }

    private void Shot()
    {
        Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }
}
