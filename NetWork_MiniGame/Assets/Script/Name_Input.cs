using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Name_Input : MonoBehaviour
{
    private AddScore add_script;

    // Start is called before the first frame update
    void Start()
    {
        add_script = GameObject.Find("Score_PL").GetComponent<AddScore>();
        this.GetComponent<InputField>().text = add_script.Get_Name();
        add_script.Change_Score(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Chage_Name(string name)
    {
        add_script.Change_Name(name);
    }
}
