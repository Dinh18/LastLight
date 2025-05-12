using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour, Weapon
{
    public int damage { get ; set ;} // sát thương của viên đạn
    public float countDown { get ; set;} // thời gian giữa hai lần bắn
    public float currTime; // thời gian thực tế giữa hai lần bắn
    [SerializeField] GameObject bulletObj; // prefab viên đạn
    private BulletGun bulletGun; // script của viên đạn
    [SerializeField] Transform firePos; // vị trí viên đạn được bắn ra
    public static Weapon Instant;
    void Awake()
    {
        Instant = this;
        
    }
    void Start()
    {
        damage = 20;
        countDown = 1.5f;
        currTime = countDown;
        bulletGun = bulletObj.GetComponent<BulletGun>();
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
        currTime -= Time.deltaTime;
        if(currTime <= 0f)
        {
            bulletGun.FireBullet(firePos);
            currTime = countDown;
        }
    }
}
