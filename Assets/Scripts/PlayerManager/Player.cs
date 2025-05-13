using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; } // singletan plyer
   
    private int hp; // máu của player
    private int armor;// giáp của player
    GameObject hand;
    Transform gun;

    public void Awake()
    {
        Instance = this;
        hand = GameObject.Find("Hand");
        gun = hand.transform.Find("Gun");
    }


    public void Start()
    {
        
    }

    public void Update()
    {
        if (gun != null)
        {
            // Debug.Log("Tên súng: " + gun.name);
        }
    }

   public void ReduceHP(int damage)
   {

   }
    
   public Vector3 getPosition()
   {
        return this.gameObject.transform.position;
   }
}
