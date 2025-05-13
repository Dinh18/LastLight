using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour, Weapon
{
    public int damage { get ; set ;} // sát thương của viên đạn
    public GameObject _bulletObj;
    public GameObject bulletObj
    {
        get => _bulletObj;
        set => _bulletObj = value;
    }
    public Transform _firePos;
    public Transform firePos 
    {
        get => _firePos;
        set => _firePos = value;
    }
    public int bulletForce { get; set; }
    public BulletFire bulletFire { get; set; }

    void Awake()
    {
        damage = 30;
        
    }
    void Start()
    {
        damage = 20;
        bulletForce = 9;
        bulletFire = new BulletFire();
    }

    void Update()
    {
        Attack();
    }
    /*
        viên đạn tự động bắn sau khoảng thời gian count dowwn
    */
    public void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            bulletFire.Fire(bulletObj,firePos,bulletForce);
        }
    }
}
