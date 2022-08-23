using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taeget_Sin_move : Target_move
{
    [Header("ìÆÇ≠ï˚å¸(ëÂÇ´Ç≥)")]
    public float bye_x,bye_y;

    [Header("âΩïbÇ≈âùïúÇ©")]
    public float Times;

    private float f;

    private const int SIN_MATH = 2;

    // Start is called before the first frame update
    void Start()
    {
        if (LI_X > 0)
            Delet_FLAG_X = true;
        if (LI_Y > 0)
            Delet_FLAG_Y = true;

        
        f = 1.0f / Times;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time++;

        vec = MyTransform.position;

        if (Stop_FLAG == false)
        {
            vec.x += X;
            vec.y += Y;
            vec.x += Mathf.Sin(SIN_MATH * Mathf.PI * f * Time.time) * bye_x;
            vec.y += Mathf.Sin(SIN_MATH * Mathf.PI * f * Time.time) * bye_y;
        }


        MyTransform.position = vec;

        if (time > Stop_move)
        {
            Stop_FLAG = true;
            time = -Stop_Length;
        }
        else if (time == 0)
        {
            Stop_FLAG = false;
        }

        //çÌèú
        DELEAT_ME();
    }
}
