using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    public Text score;

    private string PL_name="–¼–³‚µ";

    private int Score_num;

    // Start is called before the first frame update
    void Start()
    {
        Score_num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int a,int b)
    {
        Score_num += 100*(a * b);

        score.text = "Score:" + Score_num;
    }

    public void Change_Name(string name)
    {
        PL_name = name;
    }

    public string Get_Name()
    {
        return PL_name;
    }

    public int Get_Score()
    {
        return Score_num;
    }

    public void Change_Score(int score)
    {
        Score_num = score;
    }
}
