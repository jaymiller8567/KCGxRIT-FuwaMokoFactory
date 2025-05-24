using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFuwaMoco : MonoBehaviour
{
    [SerializeField ,Header("生成するオブジェクト")]
    private GameObject[] m_createObject;


    [SerializeField, Header("生成する間隔")]
    private int m_spawnTime;


    //スポーンのカウント
    private int m_cnt;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(m_createObject[0], this.gameObject.transform.position, Quaternion.identity);
        }
    }
}
