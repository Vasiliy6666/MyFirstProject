using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public int liftSpeed;
    public Transform firstPosition;
    public Transform secondPosition;
   
   private void Update()
   {
       if (Input.GetKey(KeyCode.L))
       {
           if (transform.position.y == firstPosition.position.y)
           {
               
           }
       }
      transform.position += Vector3.up * (0.1f * Time.deltaTime * liftSpeed);
   }
}
