using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    [SerializeField] private GameObject _pictureEndGame;
    [SerializeField] private EnemyGenerator _enemyGenerator;

    private void OnEnable()
    {
        _enemyGenerator.AllEnemiesDead += OnAllEnemiesDead;
    }

    private void OnDisable()
    {
        _enemyGenerator.AllEnemiesDead -= OnAllEnemiesDead;
    }

    private void OnAllEnemiesDead()
    {
        _pictureEndGame.SetActive(true);
    }
}
