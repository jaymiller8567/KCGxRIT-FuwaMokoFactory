using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerEmployee : MonoBehaviour
{
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        float angle = Mathf.Atan2(transform.position.y - mousePos.y, transform.position.x - mousePos.x);
        rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), mousePos - transform.position);
        
        transform.rotation = rotation;
    }
}
