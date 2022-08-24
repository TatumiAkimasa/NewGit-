using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teaget_Roop : MonoBehaviour
{
    public float speed_x,speed_y;                //オブジェクトのスピード
    public float radius_x,radius_y;               //円を描く半径
    private Vector3 defPosition;      //defPositionをVector3で定義する。
    float x;
    float z;

    // Use this for initialization
    void Start()
    {
        
        defPosition = this.transform.position;    //defPositionを自分のいる位置に設定する。
    }

    // Update is called once per frame
    void Update()
    {
        x = radius_x * Mathf.Sin(Time.time * speed_x);      //X軸の設定
        z = radius_y * Mathf.Cos(Time.time * speed_y);      //Z軸の設定

        transform.position = new Vector3(x + defPosition.x, defPosition.y + z, defPosition.z);  //自分のいる位置から座標を動かす。

    }
}
