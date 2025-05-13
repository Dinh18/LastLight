using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Weapon
{
    int damage { get; set; }
    static Weapon Instance;
    public void Attack();

}
