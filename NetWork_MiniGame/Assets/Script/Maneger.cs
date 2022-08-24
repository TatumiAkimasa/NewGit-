using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maneger : MonoBehaviour
{
    public Transform Parent;
    public GameObject Cell;

    // Start is called before the first frame update
    void Start()
    {
        GetRanking();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �T�[�o�[�ɃX�R�A��o�^����
    /// </summary>
    public void RegistScore(int score,string name)
    {
        var api = new API<RegistScoreResponse>("https://kc-network-lesson.com/api/ranking/regist-score");

        //const string�Ń��b�N���Ƃ�����
        api.AddRequest("uid", "�����ɃQ�[���̖��O�i��炸�j������");
        //���񂾂ƍŐV�����D�悵�đ�����B
        api.AddRequest("score", score);
        api.AddRequest("name", name);

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
        api.AddRequest("limit", 10);

        StartCoroutine(api.SendWebRequest((respone) =>
        {
            if (respone.status.Contains("NG"))
            {
                Debug.LogError(respone.error);
                return;
            }

            for (int i = 0; i < respone.ranking.Length; ++i)
            {
                GameObject cell_G = Instantiate(Cell, Vector3.zero, Quaternion.identity, Parent);
                Cell_data cell = cell_G.GetComponent<Cell_data>();

                //��������
                cell.Rank_set(respone.ranking[i].rank.ToString());
                cell.Name_set(respone.ranking[i].name);
                cell.Score_set(respone.ranking[i].score.ToString());
                cell.Time_set(respone.ranking[i].date);
            }

            for (int i = respone.ranking.Length + 1; i != 11 ; ++i)
            {
                GameObject cell_G = Instantiate(Cell, Vector3.zero, Quaternion.identity, Parent);
                Cell_data cell = cell_G.GetComponent<Cell_data>();

                //��������
                cell.Rank_set(i.ToString());
                cell.Name_set("NULL");
                cell.Score_set("NULL");
                cell.Time_set("NULL");
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