using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    int hp { get; set; }
    float speed { get; set; }
    Rigidbody2D rb { get; set; }
    Vector3 playerPos { get; set; }
    void Move ();
}
