using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] float _force;
    [SerializeField] float _duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.StartBoosting(_force, _duration);
            gameObject.SetActive(false);
        }
    }
}
