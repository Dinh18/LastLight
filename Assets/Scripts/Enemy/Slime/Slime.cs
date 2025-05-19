using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IEnemy
{
    public int hp { get; set; }
    public float speed { get ; set; }
    public Rigidbody2D rb { get ; set ; }
    public Vector3 playerPos { get ; set; }
    private WeaponFactory weaponFactory;
    // Start is called before the first frame update
    void Awake()
    {
        hp = 20;
        speed = 2f;
        rb = GetComponent<Rigidbody2D>();
        if(Player.Instance != null) playerPos = Player.Instance.getPosition();
        weaponFactory = new WeaponFactory();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(hp<=0) Destroy(this.gameObject);

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log(this.gameObject.name + " " + hp);
        if(collision.CompareTag("Attack"))
        {
            hp -= weaponFactory.getDamage(WeaponManager.instance.currWeapon.name);
            Debug.Log(this.gameObject.name + " " + hp);
        }
    }

    public void Move()
    {
        EnemyMovement.Move(speed, rb, this.gameObject.transform);
    }
}
