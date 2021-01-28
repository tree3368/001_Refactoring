using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _player; 
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _numberEnemies;
    [SerializeField] private GameObject _pictureEndGame;
    [SerializeField] private float _minDistance;

    private List<Enemy> _enemies = new List<Enemy>();

    public List<Enemy> Enemies => _enemies;

    private void Start()
    {
        CreatingEnemies();
    }

    private void Update()
    {
        if (_enemies.Count == 0)
        {
            EndGame();
        }
    }

    private void CreatingEnemies()
    {
        for (int i = 0; i < _numberEnemies; i++)
        {
            Enemy enemy = Instantiate(_enemy);
            _enemies.Add(enemy);
        }
    }

    private void EndGame()
    {
        _pictureEndGame.SetActive(true);
    }
}
