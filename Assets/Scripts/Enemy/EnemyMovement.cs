using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyMovement Instance;
    /*
    *   Enemy di chuyển đến vị trí của nhân vật
    */
    public static void Move(float speed, Rigidbody2D rb, Transform enemyTransform)
    {
        Vector3 scale = new Vector3(1,1,1);
        Vector3 playerPos = Player.Instance.getPosition();// vị trí của player
        // Nếu khoảng cách giữa enemy và player lớn hơn 1.5 thì enemy mới di chuyển
        if(Vector3.Distance(enemyTransform.position, playerPos) >= 1.5f)
        {
            // nếu x của enemy lớn hơn player thì enemy nhìn sang bên trái. ngược lại nhìn bên phải
            if( enemyTransform.position.x - playerPos.x >= 1)
            {
                scale.x = -1;
                enemyTransform.localScale = scale;
            }
            else enemyTransform.localScale = scale;
            // Vector hướng di chuyển của enemy, normalized dùng để chuẩn hóa vector(về 1) tránh di chuyển nhanh khi ở xa
            Vector3 direction = (playerPos - enemyTransform.position).normalized;
            rb.velocity = direction * speed;
        }
        else rb.velocity = Vector3.zero;
    }
}
