using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score_up : MonoBehaviour
{
    private AddScore add_script;
    public Text Score;

    public Maneger maneger;

    // Start is called before the first frame update
    void Start()
    {
        add_script = GameObject.Find("Score_PL").GetComponent<AddScore>();
        Score.text = add_script.Get_Score().ToString();

        if(add_script.Get_Score()!=-1)
        maneger.RegistScore(add_script.Get_Score(), add_script.Get_Name());
    }

    
}
