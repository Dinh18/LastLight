using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    float currTime;
    float timeDestroy;
    // Start is called before the first frame update
    void Start()
    {
        currTime = 0;
        timeDestroy = 2f;
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

}
