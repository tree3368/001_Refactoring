using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    [SerializeField] private GameObject _pictureEndGame;
    [SerializeField] private EnemyGenerator _enemyGenerator;

    private void Update()
    {
        if (_enemyGenerator.Enemies.Count == 0)
        {
            _pictureEndGame.SetActive(true);
        }
    }
}
