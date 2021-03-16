using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : Template
{
    [SerializeField] float _force;
    [SerializeField] float _duration;

    public override void HandleCollision(Player player)
    {
        player.StartBoosting(_force, _duration);
        gameObject.SetActive(false);
    }
}
