using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFuwaMoco : MonoBehaviour
{
    [SerializeField ,Header("¶¬‚·‚éƒIƒuƒWƒFƒNƒg")]
    private GameObject[] m_createObject;


    [SerializeField, Header("¶¬‚·‚éŠÔŠu")]
    private int m_spawnTime;


    //ƒXƒ|[ƒ“‚ÌƒJƒEƒ“ƒg
    private int m_cnt;
    //resultTextGameObj
    private GameObject m_resultText;
    //TotalScore‚Ì’l
    private int m_totalScore;

    // Start is called before the first frame update
    void Start()
    {
        m_resultText = GameObject.Find("ResultCanvas");
        m_cnt = 0;

       

     

        m_totalScore = m_resultText.GetComponent<ResultText>().NumberSorted();

        Debug.LogWarning(m_totalScore+"aaaa");
    }

    // Update is called once per frame
    void Update()
    {
        if (m_totalScore>0&& m_cnt--<0)
        {
            int rnd = Random.Range(0, m_createObject.Length-1);//@// ¦ 1`9‚Ì”ÍˆÍ‚Åƒ‰ƒ“ƒ_ƒ€‚È®”’l‚ª•Ô‚é
            Instantiate(m_createObject[rnd], this.gameObject.transform.position, Quaternion.identity);
            m_totalScore --;
            m_cnt = m_spawnTime;

        }
    }
}
