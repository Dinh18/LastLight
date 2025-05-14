using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Weapon
{
    int damage { get; set; }
    GameObject bulletObj{ get; set; }
    int bulletForce { get; set; }
    BulletFire bulletFire{ get; set; }
    Transform firePos{ get; set; }

    public void Attack();

}
