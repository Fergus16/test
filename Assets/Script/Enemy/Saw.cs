using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{   public float speed = 2;
int dir = 1;

public Transform rightCheck;
public Transform lefttCheck;
    // Update is called once per frame
    void FixedUpdate()
    {
      transform.Translate(Vector2.right * speed * dir* Time.fixedDeltaTime );
      if(Physics2D.Raycast(rightCheck.position, Vector2.down,2 ) == false)
      dir = -1;

      if(Physics2D.Raycast(lefttCheck.position, Vector2.down,2 ) == false)
      dir = 1;
    }
}
