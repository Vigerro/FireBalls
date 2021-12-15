using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem _dieEffect;
    
    public event UnityAction<Block> BulletHit;

    public void Break()
    {
        BulletHit?.Invoke(this);
        ParticleSystemRenderer renderer = Instantiate(_dieEffect, transform.position, _dieEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
        renderer.material.color = GetComponent<MeshRenderer>().material.color;
        Destroy(gameObject);
    }
}
