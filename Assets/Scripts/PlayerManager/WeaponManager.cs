using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public enum WeaponType {Gun, Bomb}
    public List<int> listBomb; // bom hiện tại đang có 
    public GameObject bombPrefab;
    public GameObject currWeapon; // weapon hiện tại
    public GameObject newWeapon; // weapon mới được nhặt
    public GameObject weaponPos; // vị trí player cầm súng
    public static WeaponManager instance; // singleton của WeaponManager
    public WeaponFactory weaponFactory;
    public WeaponType weaponType = WeaponType.Gun;
    private GameObject weaponHolding;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        weaponFactory = this.gameObject.GetComponent<WeaponFactory>();
        listBomb = new List<int>();

        weaponHolding = currWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        Pickup();
        // Debug.Log(listBomb.Count);
        SwapWeapon();
    }

    private void Pickup()
    {
        GameObject temp;
        if (newWeapon != null)
        {
            // temp để lưu tạm thời weapon hiện tại của player
            temp = currWeapon;
            // Debug.Log(temp.name);
            // xóa tất cả các con hiện tại của hand
            foreach (Transform child in transform)
            {
                if (child.name != "WeaponPostion") Destroy(child.gameObject);
            }
            /*
                - Khởi tạo vũ khí mới làm vũ khí hiện tại, tại vị trí cầm với vị trí cầm súng, góc quay, là con của hand
                - xóa các component không cần thiết khi súng được cầm lên
            */
            currWeapon = Instantiate(newWeapon, weaponPos.transform.position, transform.rotation, transform);
            currWeapon.name = newWeapon.name;
            Destroy(currWeapon.GetComponent<BoxCollider2D>());
            Destroy(currWeapon.GetComponent<Rigidbody2D>());
            // xóa newWeapon để nó lại là null
            Destroy(newWeapon);
            // Bỏ súng đang cầm xuống đất tại vị trí player vừa nhặt
            weaponFactory.SpawnWeapon(temp.name);
            // newWeapon = null;
            weaponType = WeaponType.Gun;
        }
    }

    private void SwapWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && weaponType != WeaponType.Gun)
        {
            foreach (Transform child in transform)
            {
                if(child.name == "Bomb")
                    Destroy(child.gameObject);
            }
            currWeapon.SetActive(true);
            weaponType = WeaponType.Gun;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && weaponType != WeaponType.Bomb && listBomb.Count > 0)
        {
            currWeapon.SetActive(false);
            GameObject bombObj = Instantiate(bombPrefab, weaponPos.transform.position, transform.rotation, transform);
            
            bombObj.name = "Bomb";
            weaponType = WeaponType.Bomb;
        }
    }
}
