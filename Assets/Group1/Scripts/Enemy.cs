using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _radiusSearchTarget;

    private Vector3 _target;

    private void Start()
    {
        TargetSearch();
    }

    private void Update()
    {
        MoveToTarget();
        if (transform.position == _target)
            TargetSearch();
    }

    private void TargetSearch()
    {
        _target = Random.insideUnitCircle * _radiusSearchTarget;
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }
}
