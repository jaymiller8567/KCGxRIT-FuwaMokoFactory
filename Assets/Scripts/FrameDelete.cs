using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameDelete : MonoBehaviour
{
    [HideInInspector] public int lifeTime;
    private int nowFrame;

    void Start()
    {
        nowFrame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (++nowFrame == lifeTime)
            Destroy(this.gameObject);
    }
}
