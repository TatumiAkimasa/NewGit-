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
    /// �T�[�o�[�ɃX�R�A��o�^����
    /// </summary>
    public void RegistScore()
    {
        var api = new API<RegistScoreResponse>("https://kc-network-lesson.com/api/ranking/regist-score");

        //const string�Ń��b�N���Ƃ�����
        api.AddRequest("uid", "�����ɃQ�[���̖��O�i��炸�j������");
        //���񂾂ƍŐV�����D�悵�đ�����B
        api.AddRequest("score", 100);
        api.AddRequest("name", "PL�̖��O");

        StartCoroutine(api.SendWebRequest(respone =>
        {
            if (respone.status.Contains("NG"))
            {
                Debug.LogError(respone.error);
                return;
            }

            //��������
            Debug.Log("�o�^�����X�R�A�̏���" + respone.rank);
        }));
    }

    public void GetRanking()
    {
        var api = new API<GetRankingResponse>("https://kc-network-lesson.com/api/ranking/get-ranking");

        //const string�Ń��b�N���Ƃ�����
        api.AddRequest("uid", "�����ɃQ�[���̖��O�i��炸�j������");
        //�����L���O��ʁZ��
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
                //��������
                Debug.Log("����" + respone.ranking[i].rank);
                Debug.Log("���O" + respone.ranking[i].name);
                Debug.Log("�X�R�A" + respone.ranking[i].score);
                Debug.Log("����" + respone.ranking[i].date);
            }
        }));
    }
}

[System.Serializable]
public class RegistScoreResponse:ResponseDataBase
{
    public int rank;//�X�R�A����
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