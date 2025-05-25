using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRanking : MonoBehaviour
{
    //操作用ベクター
    Vector3 m_vec;
    //一度に落下する速度
    [SerializeField]
    private float m_down;

    //止まる場所
    [SerializeField]
    private Transform[] m_stopTransform;

    //最後まで行ったか
    private bool m_isEnd;

    //現在のマウス位置
    private float m_mousePointY;
    //過去のマウス位置
    private float m_mouseOldPointY;
    // Start is called before the first frame update
    void Start()
    {
        m_vec = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //マウスのClickが解除されたら初期化
            m_mouseOldPointY = 0.0f;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            //初めにマウスを押したときだけ同じにする
            m_mouseOldPointY = m_mousePointY = Input.mousePosition.y; 
        }
        if (m_isEnd == false)
        {
            //指定した位置まで落下する
            if (this.gameObject.transform.position.y > m_stopTransform[0].position.y)
            {
                m_vec.y -= m_down;
            }
            else
            {
                m_vec.y = m_stopTransform[0].position.y;
                m_isEnd = true;
            }
        }
        //マウスがClickされているなら前の位置と比べて上下の移動の値を出す
        else if(Input.GetMouseButton(0))
        {

            // カーソル位置を取得
            m_mousePointY = Input.mousePosition.y;
            float pos = (m_mouseOldPointY - m_mousePointY) * 0.01f ;
            m_vec.y = m_vec.y- pos;
            m_mouseOldPointY = m_mousePointY;
           
        }
        else
        {
            m_mousePointY = 0.0f;
        }

        //指定した位置の間でしか移動できない
        if (m_isEnd == true)
        {
            if (m_vec.y < m_stopTransform[0].position.y)
            {
                m_vec.y = m_stopTransform[0].position.y;
            }
            if (m_vec.y > m_stopTransform[1].position.y)
            {

                m_vec.y = m_stopTransform[1].position.y;
            }
        }
        //移動
        this.gameObject.transform.position = m_vec;
    }
}
