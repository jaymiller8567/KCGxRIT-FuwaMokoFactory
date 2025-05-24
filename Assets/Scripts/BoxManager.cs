using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    [SerializeField] private GameObject box;
    [SerializeField] private Vector3 spawn1;
    [SerializeField] private Vector3 spawn2;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBox1();
        SpawnBox2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBox1()
    {
        var box1=Instantiate(box, spawn1,this.transform.rotation);
        box1.GetComponent<BoxScript>().boxNumber = 1;
        box1.GetComponent<BoxScript>().boxManager = this.gameObject;
    }

    public void SpawnBox2()
    {
        var box2=Instantiate(box, spawn2, this.transform.rotation);
        box2.GetComponent<BoxScript>().boxNumber = 2;
        box2.GetComponent<BoxScript>().boxManager = this.gameObject;
    }
}
