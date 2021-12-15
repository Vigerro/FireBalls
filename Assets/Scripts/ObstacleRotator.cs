using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] private float _animationTime = 3f;
    private void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), _animationTime, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }
}
