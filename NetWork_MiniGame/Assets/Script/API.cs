using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// APIの通信周りの処理を請け負う
/// </summary>
public class API<ResponseDataType>
{
    private string url;//接続先のURL
    private Dictionary<string, int> intRequestDic;//APIに送信するためのリクエスト
    private Dictionary<string, string>stringRequestDic;//APIに送信するためのリクエスト

    /// <summary>
    /// コンストラクタでURLの受け取り、各変数初期化を実行
    /// </summary>
    /// <param name="url"></param>
    public API(string url)
    {
        this.url = url;
        intRequestDic = new Dictionary<string, int>();
        stringRequestDic = new Dictionary<string, string>();
    }

    /// <summary>
    /// リクエストを受け取る関数
    /// </summary>
    /// <param name="name"></param>
    /// <param name="data"></param>
    public void AddRequest(string name,int data)
    {
        intRequestDic.Add(name, data);
    }

    public void AddRequest(string name,string data)
    {
        stringRequestDic.Add(name, data);
    }

    /// <summary>
    /// 実際に通信を行う関数
    /// </summary>
    /// <param name="callback"></param>
    /// <returns></returns>
    public IEnumerator SendWebRequest(System.Action<ResponseDataType>callback)
    {
        WWWForm from= new WWWForm();
        foreach(KeyValuePair<string,int>kvp in intRequestDic)
        {
            from.AddField(kvp.Key, kvp.Value);
        }
        foreach (KeyValuePair<string, string> kvp in stringRequestDic)
        {
            from.AddField(kvp.Key, kvp.Value);
        }

        //リクエスト作成
        UnityWebRequest www = UnityWebRequest.Post(url, from);

        //リクエストデータを実際に送信する
        yield return www.SendWebRequest();

        //エラーチェック
        if(www.result!=UnityWebRequest.Result.Success)
        {
            //エラー
            Debug.LogError(www.error);
            yield break;
        }

        //成功の時
        Debug.Log(www.downloadHandler.text);

        //レスポンスデータをパース（分離？）
        var response = JsonUtility.FromJson<ResponseDataType>(www.downloadHandler.text);
        callback(response);
    }
}

[System.Serializable]
public class ResponseDataBase
{
    public string status;
    public string error;
}

