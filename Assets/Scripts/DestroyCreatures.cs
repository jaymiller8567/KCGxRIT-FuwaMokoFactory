using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCreatures : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision collision)
    //{
    //    Debug.Log("Detected creature");
    //    collision.gameObject.SetActive(false);
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("Detected creature");
    //    collision.gameObject.SetActive(false);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Detected creature");
        collision.gameObject.SetActive(false);
    }
}
