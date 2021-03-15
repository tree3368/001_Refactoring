using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float _collisionRange;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < _collisionRange)
                enemy.Die();
        }
    }
}
