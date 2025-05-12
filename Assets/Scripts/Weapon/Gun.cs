using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour, Weapon
{
    public int damage { get ; set ;} // sát thương của viên đạn
    [SerializeField] GameObject bulletObj; // prefab viên đạn
    private BulletGun bulletGun; // script của viên đạn
    [SerializeField] Transform firePos; // vị trí viên đạn được bắn ra
    void Awake()
    {
        
    }
    void Start()
    {
        damage = 20;
        bulletGun = bulletObj.GetComponent<BulletGun>();
        bulletGun.bulletForce = 9;
        bulletGun.timeDestroy = 2f; 
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
        if(Input.GetMouseButtonDown(1))
        {
            bulletGun.FireBullet(bulletObj,firePos);
        }
    }
}
