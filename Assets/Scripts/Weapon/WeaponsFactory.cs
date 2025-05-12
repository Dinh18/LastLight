using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsFactory : MonoBehaviour
{
    public Weapon GetWeapon(string weaponType)
    {
        if(weaponType == "Gun") return new Gun();
        return null;
    }
}
