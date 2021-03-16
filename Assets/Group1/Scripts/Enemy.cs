using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Template
{
    [SerializeField] private float _speed;
    [SerializeField] private float _radiusMovement;
    [SerializeField] private float _rangeCollision;

    private Vector3 _target;

    public event UnityAction<Enemy> Death;

    private void Start()
    {
        NextTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position == _target)
            NextTarget();
    }

    private void NextTarget()
    {
        _target = Random.insideUnitCircle * _radiusMovement;
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Death?.Invoke(this);
    }

    public override void HandleCollision(Player player)
    {
        if (Vector3.Distance(transform.position, player.transform.position) < _rangeCollision)
            Die();
    }
}
