﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _movementRadius;

    private Vector3 _target;

    public event UnityAction<Enemy> Death;

    private void Start()
    {
        DefiningTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position == _target)
            DefiningTarget();
    }

    private void DefiningTarget()
    {
        _target = Random.insideUnitCircle * _movementRadius;
    }

    public void Die()
    {
        Destroy(gameObject);
        Death?.Invoke(this);
    }
}
