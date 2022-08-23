using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//一次元的な動き用
public class Target_move : MonoBehaviour
{
    //座標移動用関数
    public Transform MyTransform;
    protected Vector3 vec;

    //動く方向により削除申請の仕方を変える-止まる許可も追記
    protected bool Delet_FLAG_X, Delet_FLAG_Y,Stop_FLAG;

    //タイマー
    protected int time = 0;

    //動く方向-X,Y
    [Header("動く方向(増加量)")]
    public float X, Y;

    //限度
    [Header("削除限度")]
    public float LI_X, LI_Y;

    [Header("止まる時間間隔")]
    public int Stop_move;

    [Header("止まる時間の長さ")]
    public int Stop_Length;

    protected const int SECOND = 60;

    // Start is called before the first frame update
    void Start()
    {
        if (LI_X > 0)
            Delet_FLAG_X = true;
        if(LI_Y>0)
            Delet_FLAG_Y = true;
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
        }

        MyTransform.position = vec;

        //削除
        DELEAT_ME();

        if(time>Stop_move)
        {
            Stop_FLAG = true;
            time = -Stop_Length;
        }
        else if(time==0)
        {
            Stop_FLAG = false;
        }
                
    }

    protected void DELEAT_ME()
    {
        if (Delet_FLAG_X == true)
        {
            if (MyTransform.position.x > LI_X)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (MyTransform.position.x < LI_X)
            {
                Destroy(this.gameObject);
            }
        }
        if (Delet_FLAG_Y == true)
        {
            if (MyTransform.position.y > LI_Y)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (MyTransform.position.y < LI_Y)
            {
                Destroy(this.gameObject);
            }
        }
    }

    protected void STOP_ME(float a)
    {

    }
}
