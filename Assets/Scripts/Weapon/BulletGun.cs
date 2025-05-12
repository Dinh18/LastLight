using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletGun : MonoBehaviour, Bullet
{
    public int bulletForce { get; set; }
    public float timeDestroy { get; set; }
    private float currTime = 0;
    private GameObject bulletObj;

    
    void Update()
    {
        // DestroyBullet();
    }

    /*
    *   Xóa viên đạn sau một khoảng thời gian
    *   Xóa viên đạn khi va chạm
    */
    public void DestroyBullet()
    {
        currTime+=Time.deltaTime;
        if(currTime >= timeDestroy)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player") Destroy(this.gameObject);
    }
    /*
        Tạo viên đạn, thêm lực cho viên đạn để nó di chuyển
    */
    public void FireBullet(GameObject bulletObj, Transform firePos)
    {
        // tạo viên đạn
        GameObject bulletTmp = Instantiate(bulletObj, firePos.position, Quaternion.identity);
        // thêm lực cho viên đạn đồng thời thay đổi hướng cho viên đạn theo hướng nhìn của player
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        Debug.Log(bulletForce);
        Debug.Log(timeDestroy);
        if(Player.Instance.transform.localScale.x < 0) rb.AddForce(firePos.right * bulletForce,ForceMode2D.Impulse);
        else rb.AddForce(firePos.right * bulletForce * -1,ForceMode2D.Impulse);
    }
}
