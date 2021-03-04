using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _movementRadius;
    [SerializeField] private float _collisionRange;

    private Vector3 _target;
    private Player _player;

    public event UnityAction<Enemy> Death;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        NextTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position == _target)
            NextTarget();
        if (Vector3.Distance(transform.position, _player.transform.position) < _collisionRange)
            Die();
    }

    private void NextTarget()
    {
        _target = Random.insideUnitCircle * _movementRadius;
    }

    public void Die()
    {
        Destroy(gameObject);
        _player.ActivateSpeedUp();
        Death?.Invoke(this);
    }
}
