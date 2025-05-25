using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject[] canvas;

    private int m_cnt;
    // Start is called before the first frame update
    void Start()
    {
        m_cnt = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown&&m_cnt--<0)
        {
            canvas[0].SetActive(false);
            canvas[1 ].SetActive(true);
        }
    }
}
