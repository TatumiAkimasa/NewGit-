using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ꎟ���I�ȓ����p
public class Target_move : MonoBehaviour
{
    //���W�ړ��p�֐�
    public Transform MyTransform;
    protected Vector3 vec;

    //���������ɂ��폜�\���̎d����ς���-�~�܂鋖���ǋL
    protected bool Delet_FLAG_X, Delet_FLAG_Y,Stop_FLAG;

    //�^�C�}�[
    protected int time = 0;

    //��������-X,Y
    [Header("��������(������)")]
    public float X, Y;

    //���x
    [Header("�폜���x")]
    public float LI_X, LI_Y;

    [Header("�~�܂鎞�ԊԊu")]
    public int Stop_move;

    [Header("�~�܂鎞�Ԃ̒���")]
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

        //�폜
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
