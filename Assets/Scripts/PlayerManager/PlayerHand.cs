using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 mousePos; // vị trí con trỏ chuột
    public static PlayerHand Instance;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateHand();
    }
    private void RotateHand()
    {
        // Thay đổi vị trí con trỏ chuột trên màn hình thành vị trí con trỏ chuột trên hệ tọa độ của game
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Vector chỉ hướng giữa vị triscon trỏ chuột và tay player
        Vector3 dir = transform.position - mousePos;
        dir.Normalize();
        // Góc xoay tính theo độ
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // Xoay tay player theo con trỏ chuột
        // Debug.Log(angle);
        if(Player.Instance.transform.localScale.x > 0 && angle > -40 && angle < 20)
        transform.rotation = Quaternion.Euler(0,0,angle); 
        if((Player.Instance.transform.localScale.x < 0 &&angle <=-140 && angle > -180) || (angle >=160 && angle < 180))
        transform.rotation = Quaternion.Euler(0,0,angle-180); 
    }
}
