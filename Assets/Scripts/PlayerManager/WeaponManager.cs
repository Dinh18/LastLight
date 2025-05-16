using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject currWeapon;
    public GameObject newWeapon;
    public GameObject weaponPos;
    public static WeaponManager instance;
    private WeaponFactory weaponFactory;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        weaponFactory = this.gameObject.GetComponent<WeaponFactory>();
    }

    // Update is called once per frame
    void Update()
    {
        Pickup();
    }

    private void Pickup()
    {
        GameObject temp;
        if(newWeapon != null)
        {
            temp = currWeapon;
            Debug.Log(temp.name);
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            currWeapon = Instantiate(newWeapon, weaponPos.transform.position, transform.rotation, transform);
            currWeapon.name = newWeapon.name;
            Destroy(currWeapon.GetComponent<BoxCollider2D>());
            Destroy(currWeapon.GetComponent<Rigidbody2D>());

            Destroy(newWeapon);
            // GameObject gameObject = Instantiate(temp,Player.Instance.transform.position,Quaternion.identity);
            // gameObject.name = temp.name;
            // gameObject.AddComponent<BoxCollider2D>();
            // gameObject.AddComponent<Rigidbody2D>();
            // gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            // gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            weaponFactory.spawnWeapon(temp.name);
            newWeapon = null;

        }

    }


}
