using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private bool isPlane = false;
    private bool isExplode = false;
    private float time = 3f;
    private float currTime = 0f;
    public Animator animator;
    private WeaponFactory weaponFactory;
    // Start is called before the first frame update
    void Start()
    {
        weaponFactory = new WeaponFactory();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlaneBomb()
    {
        if (WeaponManager.instance.weaponType == WeaponManager.WeaponType.Bomb && Input.GetMouseButtonDown(0))
        {
            WeaponManager.instance.weaponFactory.SpawnWeapon("Bomb");
            isPlane = true;
        }
    }
    private void Explode()
    {
        if (isPlane)
        {
            currTime += Time.deltaTime;
            if (currTime >= time)
            {
                isExplode = true;
            }
            animator.SetBool("isExplode", isExplode);
        }
    }
}
