using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string _verticalDirection = "Vertical";
    private const string _horizontalDirection = "Horizontal";

    [SerializeField] private float _speed;

    private void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis(_horizontalDirection), Input.GetAxis(_verticalDirection), 0);

        transform.Translate(moveDirection * _speed * Time.deltaTime);
    }

    public void StartBoosting(float force, float duration)
    {
        StartCoroutine(Boosting(force, duration));
    }

    private IEnumerator Boosting(float force, float duration)
    {
        _speed += force;
        yield return new WaitForSeconds(duration);
        _speed -= force;
    }
}
