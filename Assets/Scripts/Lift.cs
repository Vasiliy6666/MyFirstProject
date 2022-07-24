using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public int liftSpeed;
    public Transform firstPosition;
    public Transform secondPosition;
    private Vector3 _activePosition;

    private void Update()
    {
        if (_activePosition != Vector3.zero)
        {
            if (_activePosition == transform.position)
            {
                _activePosition = Vector3.zero;
                return;
            }

            var moveDistance = liftSpeed * Time.deltaTime;
            if (Math.Abs(transform.position.y - _activePosition.y) < moveDistance)
            {
                transform.position = _activePosition;
                _activePosition = Vector3.zero;
                return;
            }
            transform.position += (transform.position.y - _activePosition.y)
                /(Math.Abs(transform.position.y - _activePosition.y)) * -Vector3.up * moveDistance;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            _activePosition = transform.position == firstPosition.position
                ? secondPosition.position
                : firstPosition.position;
        }
    }
}
