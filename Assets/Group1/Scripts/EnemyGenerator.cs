using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private int _enemies;

    private List<Enemy> _createdEnemies = new List<Enemy>();

    public event UnityAction AllEnemiesDead;

    private void Start()
    {
        CreateEnemies();
    }

    private void CreateEnemies()
    {
        for (int i = 0; i < _enemies; i++)
        {
            Enemy enemy = Instantiate(_template);
            _createdEnemies.Add(enemy);
            enemy.Death += OnDeath;
        }
    }

    private void OnDeath(Enemy enemy)
    {
        enemy.Death -= OnDeath;
        _createdEnemies.Remove(enemy);
        if (_createdEnemies.Count == 0)
            AllEnemiesDead?.Invoke();
    }
}
