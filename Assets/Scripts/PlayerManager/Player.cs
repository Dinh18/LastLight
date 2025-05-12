using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public static Player Instance { get; private set; } // singletan plyer
   
   private int hp; // máu của player
   private int armor;// giáp của player

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

   public void ReduceHP(int damage)
   {

   }
    
   public Vector3 getPosition()
   {
        return this.gameObject.transform.position;
   }
}
