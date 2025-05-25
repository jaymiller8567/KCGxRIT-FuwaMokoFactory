using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject[] canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            canvas[0].SetActive(false);
            canvas[1 ].SetActive(true);
        }
    }
}
