using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Weapon
{
    int damage { get; set; }
    float countDown { get; set; }
    public void Attack();

}
