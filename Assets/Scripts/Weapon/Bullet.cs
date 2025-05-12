using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Bullet
{
    int bulletForce { get; set; }
    float timeDestroy  { get; set; }
    public void FireBullet(GameObject bulletObj,Transform firePos);
}
