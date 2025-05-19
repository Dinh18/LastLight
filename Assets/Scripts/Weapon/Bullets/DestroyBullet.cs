using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    float currTime;
    float timeDestroy;
    private WeaponFactory weaponFactory;
    // Start is called before the first frame update
    void Start()
    {
        currTime = 0;
        timeDestroy = 2f;
        weaponFactory = new WeaponFactory();
    }

    // Update is called once per frame
    void Update()
    {
        currTime+= Time.deltaTime;
        if(currTime >= timeDestroy)
        {
            currTime = 0;
            Destroy(this.gameObject);
        }   
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
