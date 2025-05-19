using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public enum WeaponType {Gun, Bomb}
    public List<int> listBomb; // bom hiện tại đang có 
    public GameObject bomb;
    public GameObject currGun; // weapon hiện tại
    public GameObject newGun; // weapon mới được nhặt
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

        weaponHolding = currGun;
    }

    // Update is called once per frame
    void Update()
    {
        Pickup();
        // Debug.Log(listBomb.Count);
        SwapWeapon();
        WeaponHolding();
    }

    private void Pickup()
    {
        GameObject temp;
        if (newGun != null)
        {
            // temp để lưu tạm thời weapon hiện tại của player
            temp = currGun;
            // Debug.Log(temp.name);
            // xóa tất cả các con hiện tại của hand
            foreach (Transform child in transform)
            {
                if (child.name != "WeaponPostion" && child.name != "BombHolding") Destroy(child.gameObject);
            }
            /*
                - Khởi tạo vũ khí mới làm vũ khí hiện tại, tại vị trí cầm với vị trí cầm súng, góc quay, là con của hand
                - xóa các component không cần thiết khi súng được cầm lên
            */
            currGun = Instantiate(newGun, weaponPos.transform.position, transform.rotation, transform);
            currGun.name = newGun.name;
            Destroy(currGun.GetComponent<BoxCollider2D>());
            Destroy(currGun.GetComponent<Rigidbody2D>());
            // xóa newWeapon để nó lại là null
            Destroy(newGun);
            // Bỏ súng đang cầm xuống đất tại vị trí player vừa nhặt
            weaponFactory.SpawnWeapon(temp.name);
            // newWeapon = null;
            weaponType = WeaponType.Gun;
        }
    }
    /*
        - Nếu weaponType = gun thì set active currGun = true
        - Nếu weaponType = bomb thì:
            + Nếu số lượng bomb > 0 thì set active Bomb = true
            + Nếu số lượng bomb = 0 thì set weaponType = gun
    */

    public void WeaponHolding()
    {
        if (weaponType == WeaponType.Gun)
        {
            currGun.SetActive(true);
            bomb.SetActive(false);
        }
        if (weaponType == WeaponType.Bomb)
        {
            if (listBomb.Count > 0)
            {
                bomb.SetActive(true);
                currGun.SetActive(false);
            }
            else
            {
                bomb.SetActive(false);
                weaponType = WeaponType.Gun;
            }
        }
    }

    private void SwapWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // foreach (Transform child in transform)
            // {
            //     if (child.name == "Bomb")
            //         Destroy(child.gameObject);
            // }
            // currWeapon.SetActive(true);
            weaponType = WeaponType.Gun;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // currWeapon.SetActive(false);
            // GameObject bombObj = Instantiate(bombPrefab, weaponPos.transform.position, transform.rotation, transform);
            // bombObj.name = "Bomb";
            weaponType = WeaponType.Bomb;
        }
    }
}
