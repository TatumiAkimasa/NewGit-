using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taeget_Sumon : MonoBehaviour
{
    public MonoBehaviour script;
    private int time_ = 0;

    [Header("ë“ã@éûä‘")]
    public int Wait_time;

    [Header("èoåªéûä‘")]
    public int Sumoning_time;

    protected const int SECOND = 60;
    // Start is called before the first frame update
    void Start()
    {
        //éûä‘í≤êÆ
        Sumoning_time += Wait_time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time_++;

        if(time_==Wait_time*SECOND)
        {
            this.gameObject.GetComponent<Collider2D>().enabled = true;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            if(script!=null)
            script.enabled = true;
        }
        else if(time_==Sumoning_time)
        {
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            if (script != null)
                script.enabled = false;
        }
    }
}
