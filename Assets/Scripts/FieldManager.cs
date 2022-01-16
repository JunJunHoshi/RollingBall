using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    //ステージの初期のジャイロ情報を取得し、カメラが最初に向くべき方向を決定
    private void Start()
    {
        var rotRH = new Quaternion(Input.gyro.attitude.x, -Input.gyro.attitude.z, Input.gyro.attitude.y, Input.gyro.attitude.w);
        var rot = rotRH.eulerAngles;

        //カメラのローテーションはy軸だけでOK
        rot = new Vector3(0, rot.y, 0);
        transform.rotation = Quaternion.Euler(rot);  
    }

}
