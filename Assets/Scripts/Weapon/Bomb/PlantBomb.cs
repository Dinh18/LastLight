using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public Animator animator;
    public WeaponFactory weaponFactory;
    // Start is called before the first frame update
    void Start()
    {
        weaponFactory = WeaponManager.instance.weaponFactory;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlaneBomb();
        
    }

    private void PlaneBomb()
    {
        if (WeaponManager.instance.weaponType == WeaponManager.WeaponType.Bomb && Input.GetMouseButtonDown(0))
        {
            weaponFactory.SpawnWeapon("Bomb");
            // WeaponManager.instance.listBomb.Remove(0);

        }
    }
    
}
