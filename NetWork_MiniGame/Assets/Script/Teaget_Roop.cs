using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teaget_Roop : MonoBehaviour
{
    public float speed_x,speed_y;                //�I�u�W�F�N�g�̃X�s�[�h
    public float radius_x,radius_y;               //�~��`�����a
    private Vector3 defPosition;      //defPosition��Vector3�Œ�`����B
    float x;
    float z;

    // Use this for initialization
    void Start()
    {
        
        defPosition = this.transform.position;    //defPosition�������̂���ʒu�ɐݒ肷��B
    }

    // Update is called once per frame
    void Update()
    {
        x = radius_x * Mathf.Sin(Time.time * speed_x);      //X���̐ݒ�
        z = radius_y * Mathf.Cos(Time.time * speed_y);      //Z���̐ݒ�

        transform.position = new Vector3(x + defPosition.x, defPosition.y + z, defPosition.z);  //�����̂���ʒu������W�𓮂����B

    }
}
