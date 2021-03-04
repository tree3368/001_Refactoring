using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    [SerializeField] private GameObject _pictureEndGame;

    public void IncludePicture()
    {
        _pictureEndGame.SetActive(true);
    }
}
