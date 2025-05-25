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
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        rotation = Quaternion.Angle(transform.position, mousePos);
            
            //Mathf.Atan2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.rotation = rotation;
    }
}
