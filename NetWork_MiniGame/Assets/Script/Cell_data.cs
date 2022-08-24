using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell_data : MonoBehaviour
{
    public Text Name, Rank, Score, Time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Name_set(string name)
    {
        Name.text = name;
    }

    public void Rank_set(string rank)
    {
        Rank.text = rank;
    }

    public void Time_set(string time)
    {
        Time.text = time;
    }

    public void Score_set(string score)
    {
        Score.text = score;
    }
}
