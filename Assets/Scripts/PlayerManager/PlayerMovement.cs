using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool facingLeft = true; // hướng nhìn của player
    private Rigidbody2D rb;
    private Vector2 movement; // vector hướng di chuyển của player
    private float speed = 5f; // tốc độ của player
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void FixedUpdate()
    {
        rb.velocity = movement * speed;
    }
    /*
        Bắt sự kiện khi bấm nút di chuyển, thay đổi hướng nhìn của player
    */
    public void Move()
    {
        Vector3 scale = this.gameObject.transform.localScale;
        // thay đổi hướng nhìn của player sang bên phải
        if (Input.GetKey(KeyCode.D))
        {
            if(facingLeft)
            {
                scale.x *= -1;
                this.gameObject.transform.localScale = scale;
                facingLeft = false;
            }
        }
        // thay đổi hướng nhìn của player sang bên trái
        if (Input.GetKey(KeyCode.A))
        {
            if(!facingLeft)
            {
                scale.x *= -1;
                this.gameObject.transform.localScale = scale;
                facingLeft = true;
            }
           
        }
        // Thay đổi animation của player
        float s = Mathf.Abs(movement.x) + Mathf.Abs(movement.y);
        animator.SetFloat("Speed",s);
        // bắt sự kiện bấm nút dui chuyển của player
        movement.x = Input.GetAxisRaw("Horizontal"); // di chuyển sang trái sang phải
        movement.y = Input.GetAxisRaw("Vertical"); // di chuyển lên xuống
        movement.Normalize(); // tránh nhanh hơn theo đường chéo
    }
    
}
