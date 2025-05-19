using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponFactory : MonoBehaviour
{
    public GameObject gun;
    public GameObject rifle;
    public GameObject Bomb;
    /*
        - khởi Spawn súng theo prefab
        - trả về null nếu tên súng không có trong danh sách attribute
    */
    public GameObject SpawnWeapon(string nameWeapon)
    {
        if (nameWeapon == "Gun")
        {
            GameObject gameObject = Instantiate(gun, Player.Instance.transform.position, Quaternion.identity);
            gameObject.name = nameWeapon;
            return gameObject;
        }
        if (nameWeapon == "Rifle")
        {
            GameObject gameObject = Instantiate(rifle, Player.Instance.transform.position, Quaternion.identity);
            gameObject.name = nameWeapon;
            return gameObject;
        }
        if (name == "Bomb")
        {
            GameObject gameObject = Instantiate(rifle, Player.Instance.transform.position, Quaternion.identity);
            return gameObject;
        }
        return null;
    }

    public int getDamage(string nameWeapon)
    {
        if(nameWeapon == "Gun") return Gun.instance.damage;
        if(nameWeapon == "Rifle") return Rifle.instance.damage;
        else return 0;
    }
}
