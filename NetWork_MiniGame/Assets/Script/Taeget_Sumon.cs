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

    public Collider2D[] Coliders = new Collider2D[4];

    public bool No_Destory;

    public AudioClip Sound1;
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

        if(time_==Wait_time)
        {
            for(int i=0;i!=4;i++)
            {
                if(Coliders[i]!=null)
                Coliders[i].enabled = true;
            }
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            if(script!=null)
            script.enabled = true;

            this.GetComponent<AudioSource>().PlayOneShot(Sound1);
        }
        else if(time_==Sumoning_time)
        {
            Destroy(this.gameObject);
        }
    }

    public void Destroy()
    {
        if (No_Destory != true)
            Destroy(this.gameObject);
        else
            ;
    }
}
