using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private int _numberEnemies;

    private List<Enemy> _enemies = new List<Enemy>();

    public List<Enemy> Enemies => _enemies;

    private void Start()
    {
        CreatingEnemies();
    }

    private void CreatingEnemies()
    {
        for (int i = 0; i < _numberEnemies; i++)
        {
            Enemy enemy = Instantiate(_template);
            _enemies.Add(enemy);
            enemy.Death += OnDeath;
        }
    }

    private void OnDeath(Enemy enemy)
    {
        enemy.Death -= OnDeath;
        _enemies.Remove(enemy);   
    }
}
