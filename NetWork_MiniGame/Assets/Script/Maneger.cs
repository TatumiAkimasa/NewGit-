using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maneger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RegistScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// サーバーにスコアを登録する
    /// </summary>
    public void RegistScore()
    {
        var api = new API<RegistScoreResponse>("https://kc-network-lesson.com/api/ranking/regist-score");

        //const stringでロックしとこうね
        api.AddRequest("uid", "ここにゲームの名前（被らず）を入れる");
        //同列だと最新側が優先して贈られる。
        api.AddRequest("score", 100);
        api.AddRequest("name", "PLの名前");

        StartCoroutine(api.SendWebRequest(respone =>
        {
            if (respone.status.Contains("NG"))
            {
                Debug.LogError(respone.error);
                return;
            }

            //処理成功
            Debug.Log("登録したスコアの順位" + respone.rank);
        }));
    }

    public void GetRanking()
    {
        var api = new API<GetRankingResponse>("https://kc-network-lesson.com/api/ranking/get-ranking");

        //const stringでロックしとこうね
        api.AddRequest("uid", "ここにゲームの名前（被らず）を入れる");
        //ランキング上位〇名
        api.AddRequest("limit", 5);

        StartCoroutine(api.SendWebRequest((respone) =>
        {
            if (respone.status.Contains("NG"))
            {
                Debug.LogError(respone.error);
                return;
            }

            for (int i = 0; i < respone.ranking.Length; ++i)
            {
                //処理成功
                Debug.Log("順位" + respone.ranking[i].rank);
                Debug.Log("名前" + respone.ranking[i].name);
                Debug.Log("スコア" + respone.ranking[i].score);
                Debug.Log("日時" + respone.ranking[i].date);
            }
        }));
    }
}

[System.Serializable]
public class RegistScoreResponse:ResponseDataBase
{
    public int rank;//スコア順位
}

[System.Serializable]
public class GetRankingResponse:ResponseDataBase
{
    public RankingData[] ranking;
}

[System.Serializable]
public class RankingData
{
    public string name;
    public int score;
    public string date;
    public int rank;
        
}