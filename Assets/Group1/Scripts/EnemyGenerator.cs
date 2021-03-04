using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private int _enemies;
    [SerializeField] private GameResult _gameResult;

    private List<Enemy> _createdEnemies = new List<Enemy>();

    public List<Enemy> CreatedEnemies => _createdEnemies;

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
            _gameResult.IncludePicture();
    }
}
