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
           if (_activePosition == transform.position) _activePosition = Vector3.zero;
           transform.position = Vector3.MoveTowards(
               transform.position, 
               _activePosition, 
               liftSpeed * Time.deltaTime);
       }
       else if (Input.GetKey(KeyCode.L))
       {
           _activePosition = transform.position == firstPosition.position ? secondPosition.position : firstPosition.position;
       }
   }
}
