using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// API�̒ʐM����̏����𐿂�����
/// </summary>
public class API<ResponseDataType>
{
    private string url;//�ڑ����URL
    private Dictionary<string, int> intRequestDic;//API�ɑ��M���邽�߂̃��N�G�X�g
    private Dictionary<string, string>stringRequestDic;//API�ɑ��M���邽�߂̃��N�G�X�g

    /// <summary>
    /// �R���X�g���N�^��URL�̎󂯎��A�e�ϐ������������s
    /// </summary>
    /// <param name="url"></param>
    public API(string url)
    {
        this.url = url;
        intRequestDic = new Dictionary<string, int>();
        stringRequestDic = new Dictionary<string, string>();
    }

    /// <summary>
    /// ���N�G�X�g���󂯎��֐�
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
    /// ���ۂɒʐM���s���֐�
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

        //���N�G�X�g�쐬
        UnityWebRequest www = UnityWebRequest.Post(url, from);

        //���N�G�X�g�f�[�^�����ۂɑ��M����
        yield return www.SendWebRequest();

        //�G���[�`�F�b�N
        if(www.result!=UnityWebRequest.Result.Success)
        {
            //�G���[
            Debug.LogError(www.error);
            yield break;
        }

        //�����̎�
        Debug.Log(www.downloadHandler.text);

        //���X�|���X�f�[�^���p�[�X�i�����H�j
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

