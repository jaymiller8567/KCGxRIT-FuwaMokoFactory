using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject creaturePrefab;

    private List<GameObject> creatureList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        creatureList.Add(Instantiate(creaturePrefab));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
