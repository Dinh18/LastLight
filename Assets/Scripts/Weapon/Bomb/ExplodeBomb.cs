using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBomb : MonoBehaviour
{
    private bool isDelete = false;
    private float time = 3f;
    private float currTime = 0f;
    public Animator animator;
    // public string targetStateName;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Explode();
        if (!isDelete)
        {
            WeaponManager.instance.listBomb.RemoveAt(0);
            if (WeaponManager.instance.listBomb.Count == 0) WeaponManager.instance.weaponType = WeaponManager.WeaponType.Gun;
            isDelete = true;
        }
    }
    private void Explode()
    {
        currTime += Time.deltaTime;
        if (currTime >= time)
        {
            animator.SetBool("isExplode", true);
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (currTime >= time + 2)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
