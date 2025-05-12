using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletGun : MonoBehaviour, Bullet
{
    private int bulletForce = 9; // lực của viên đạn
    private float timeDestroy = 2f; // thời gian hủy viên đạn
    private float currTime = 0f; // thời gian tồn tại thực tế của viên đạn
    /*
        Tạo viên đạn, thêm lực cho viên đạn để nó di chuyển
    */
    public void FireBullet(Transform firePos)
    {
        // tạo viên đạn
        GameObject bulletTmp = Instantiate(this.gameObject, firePos.position, Quaternion.identity);
        // thêm lực cho viên đạn đồng thời thay đổi hướng cho viên đạn theo hướng nhìn của player
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        if(Player.Instance.transform.localScale.x < 0) rb.AddForce(firePos.right * bulletForce,ForceMode2D.Impulse);
        else rb.AddForce(firePos.right * bulletForce * -1,ForceMode2D.Impulse);
    }
    void Update()
    {
        DestroyBullet();
    }
    /*
    *   Xóa viên đạn sau một khoảng thời gian
    *   Xóa viên đạn khi va chạm
    */
    private void DestroyBullet()
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
}
