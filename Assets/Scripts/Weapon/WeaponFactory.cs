using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : MonoBehaviour
{
    public GameObject gun;
    public GameObject rifle;
    public GameObject spawnWeapon(string nameWeapon)
    {
        if(nameWeapon == "Gun")
        {
            GameObject gameObject = Instantiate(gun, Player.Instance.transform.position, Quaternion.identity);
            gameObject.name = "Gun";
            return gameObject;
        }
        if(nameWeapon == "Rifle")
        {
            GameObject gameObject = Instantiate(rifle, Player.Instance.transform.position, Quaternion.identity);
            gameObject.name = "Rifle";
            return gameObject;
        }
        return null;
    }
}
