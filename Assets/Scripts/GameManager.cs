using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int posMin;
    private int posMax;
    [SerializeField] GameObject enemy;
    public List<GameObject> slime = new List<GameObject>();
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // CheckEnemies();
        // while(slime.Count < 10)
        // {
        //     Spawn();
        // }
    }
    public void Spawn()
    {
        int x, y;
        posMin = (int)Player.Instance.getPosition().x - 20;
        posMax = (int)Player.Instance.getPosition().x  + 20;
        float distantMin = Mathf.Sqrt(13*13 + 7*7);
        x = Random.Range(posMin, posMax);
        y = Random.Range(posMin, posMax);
        Vector3 vt3 = new Vector3(x, y, 0);
        while(Vector3.Distance(vt3, Player.Instance.transform.position) <= distantMin)
        {
            x = Random.Range(posMin, posMax);
            y = Random.Range(posMin, posMax);
            vt3.x = x;
            vt3.y = y;
        }
        GameObject enemyTMP = Instantiate(enemy,vt3,Quaternion.identity);
        slime.Add(enemyTMP);
    }

    private void CheckEnemies()
    {
        slime.RemoveAll(slime => slime == null);
    }
}
