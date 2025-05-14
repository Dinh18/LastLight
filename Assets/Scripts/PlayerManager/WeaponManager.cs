using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject currWeapon;
    public GameObject newWeapon;
    public static WeaponManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {

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
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            currWeapon = Instantiate(newWeapon, transform.position, transform.rotation, transform);
            Destroy(currWeapon.GetComponent<BoxCollider2D>());
            Destroy(currWeapon.GetComponent<Rigidbody2D>());


            Destroy(newWeapon);
            GameObject gameObject = Instantiate(temp,Player.Instance.transform.position,Quaternion.identity);
            gameObject.AddComponent<BoxCollider2D>();
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            gameObject.AddComponent<Rigidbody2D>();
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            newWeapon = null;

        }

    }


}
