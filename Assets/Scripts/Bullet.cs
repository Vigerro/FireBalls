using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _moveDirection;

    private void Start()
    {
        _moveDirection = transform.forward;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Block block))
        {
            block.Break();
            Destroy(gameObject);
        }
        else if(other.TryGetComponent(out Obstacle obstacle))
        {
            _moveDirection = Vector3.back + Vector3.up;
            Destroy(gameObject, 2f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
