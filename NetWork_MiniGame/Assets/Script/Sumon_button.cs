using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sumon_button : MonoBehaviour
{
    [Header("‘Ò‹@ŽžŠÔ")]
    public int Wait_time;

    public Image image;
    public Button button;
    public Text text;

    private int time_=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time_++;

        if (time_ == Wait_time)
        {
            image.enabled = true;
            button.enabled = true;
            text.enabled = true;
        }
    }
}
