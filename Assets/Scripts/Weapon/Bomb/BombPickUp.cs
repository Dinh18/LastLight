using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPickUp : MonoBehaviour
{
    private bool playerInTrigger = false;
    private GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {
        bomb = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            WeaponManager.instance.listBomb.Add(1);
            Destroy(bomb);
        }
    }

    void FixedUpdate()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInTrigger = true;
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInTrigger = false;     
    }
}
