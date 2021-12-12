using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ballRun : MonoBehaviour {
 
	private float  speed = 10.0f;
	private Quaternion ori = default;
 
	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
		ori = Input.gyro.attitude;
	}
	
	// Update is called once per frame
	void Update () {

        Quaternion rotRH = Input.gyro.attitude;

        // 現在の自身の回転(rot)と開始時の回転(ori)との差分を取得し、それを回転情報と置く。
        Quaternion rotDF = rotRH * Quaternion.Inverse(ori);
        Quaternion rot = new Quaternion(-rotDF.x, 0f, -rotDF.y, rotDF.w);

        // 合成して、自身に設定
        this.transform.rotation = rot;

    }
}