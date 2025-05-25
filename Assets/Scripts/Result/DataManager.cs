using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [HideInInspector] public SaveRankingData data;     // json変換するデータのクラス
    string filepath;                            // jsonファイルのパス
    string fileName = "RankingData.json";              // jsonファイル名

    //-------------------------------------------------------------------
    // 開始時にファイルチェック、読み込み
    void Awake()
    {
        //setting 60 fps
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        // パス名取得
        filepath = Application.dataPath + "/" + fileName ;

        Debug.LogWarning("ロード");

        // ファイルがないとき、ファイル作成
        if (!File.Exists(filepath))
        {
            Save(data);

        }

        // ファイルを読み込んでdataに格納
        data = Load(filepath);
        for (int i = 0; i < data.rankingData.Length; i++)
        {
            if (data.rankingData[i] <=0)
            {
                data.rankingData[i] = 0;
            }

        }



    }

    //-------------------------------------------------------------------
    // jsonとしてデータを保存
    void Save(SaveRankingData data)
    {
        string json = JsonUtility.ToJson(data);                 // jsonとして変換
        StreamWriter wr = new StreamWriter(filepath, false);    // ファイル書き込み指定
        wr.WriteLine(json);                                     // json変換した情報を書き込み
        wr.Close();                                             // ファイル閉じる
    }

    // jsonファイル読み込み
    SaveRankingData Load(string path)
    {
        StreamReader rd = new StreamReader(path);               // ファイル読み込み指定
        string json = rd.ReadToEnd();                           // ファイル内容全て読み込む
        rd.Close();                                             // ファイル閉じる

        return JsonUtility.FromJson<SaveRankingData>(json);            // jsonファイルを型に戻して返す
    }

    public void SaveStart()
    {

        Save(data);
        Debug.LogWarning("Saveができました");
    }

    //-------------------------------------------------------------------
    // ゲーム終了時に保存
    void OnDestroy()
    {
        Save(data);
    }
}
