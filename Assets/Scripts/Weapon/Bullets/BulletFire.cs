using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public void Fire(GameObject bulletObj, Transform firePos, int bulletForce)
    {
        // tạo viên đạn
        GameObject bulletTmp = Instantiate(bulletObj, firePos.position, Quaternion.identity);
        bulletTmp.transform.rotation = PlayerHand.Instance.transform.rotation;
        // thêm lực cho viên đạn đồng thời thay đổi hướng cho viên đạn theo hướng nhìn của player
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        if(Player.Instance.transform.localScale.x < 0) rb.AddForce(firePos.right * bulletForce,ForceMode2D.Impulse);
        else rb.AddForce(firePos.right * bulletForce * -1,ForceMode2D.Impulse);
    }
}
