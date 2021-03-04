using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string _verticalDirection = "Vertical";
    private const string _horizontalDirection = "Horizontal";

    [SerializeField] private float _speed;
    [SerializeField] private float _speedUpMultiplier;
    [SerializeField] private float _speedUpDuration;

    private void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis(_horizontalDirection), Input.GetAxis(_verticalDirection), 0);

        transform.Translate(moveDirection * _speed * Time.deltaTime);
    }

    public void ActivateSpeedUp()
    {
        StartCoroutine(SpeedUpBonus());
    }

    private IEnumerator SpeedUpBonus()
    {
        _speed *= _speedUpMultiplier;
        yield return new WaitForSeconds(_speedUpDuration);
        _speed /= _speedUpMultiplier;
    }
}
