using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour, IWeapon
{
    public int damage { get; set; }
    [SerializeField] private GameObject _bulletObj;
    public GameObject bulletObj 
    {
        get => _bulletObj; 
        set => _bulletObj = value; 
    }
    [SerializeField] private Transform _firePos;
    public Transform firePos 
    { 
        get => _firePos; 
        set => _firePos = value; 
    }
    public int bulletForce { get; set; }
    public BulletFire bulletFire { get; set; }
    public static Rifle instance;

    void Awake()
    {
        damage = 10;
        bulletForce = 9;
        bulletFire = new BulletFire();
        instance = this;
    }
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();   
    }

    public void Attack()
    {
        if(Input.GetMouseButtonDown(0) && WeaponManager.instance.currGun.name == "Rifle")
        {

            bulletFire.Fire(bulletObj,firePos,bulletForce);
        }
    }

}
