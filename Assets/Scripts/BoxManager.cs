using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    [SerializeField] private GameObject box;
    [SerializeField] private Vector3 spawn1;
    [SerializeField] private Vector3 spawn2;

    [SerializeField] private Sprite mokoSprite;
    [SerializeField] private Sprite fuwaSprite;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBox1();
        SpawnBox2();
    }

    public void SpawnBox1()
    {
        var box1=Instantiate(box, new Vector3(spawn1.x,10,0),this.transform.rotation);
        box1.GetComponent<BoxScript>().boxNumber = 1;
        box1.GetComponent<BoxScript>().boxManager = this.gameObject;
        box1.GetComponent<SpriteRenderer>().sprite = mokoSprite;
    }

    public void SpawnBox2()
    {
        var box2=Instantiate(box, new Vector3(spawn2.x, 10, 0), this.transform.rotation);
        box2.GetComponent<BoxScript>().boxNumber = 2;
        box2.GetComponent<BoxScript>().boxManager = this.gameObject;
        box2.GetComponent<SpriteRenderer>().sprite = fuwaSprite;
    }
}
