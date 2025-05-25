using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerAnimationHandler : MonoBehaviour
{

    [SerializeField] private GameObject leftTiger;
    [SerializeField] private GameObject rightTiger;

    [SerializeField] private string painAnimName;
    [SerializeField] private string angryAnimName;

    private static TigerAnimationHandler _instance;

    public static TigerAnimationHandler instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<TigerAnimationHandler>();
            }

            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void leftPain()
    {
        leftTiger.GetComponent<Animator>().Play(painAnimName);
        rightTiger.GetComponent<Animator>().Play(angryAnimName);
        Debug.Log("playing left pain anim");

    }

    public void rightPain()
    {
        rightTiger.GetComponent<Animator>().Play(painAnimName);
        leftTiger.GetComponent<Animator>().Play(angryAnimName);
        Debug.Log("playing right pain anim");

    }
}
