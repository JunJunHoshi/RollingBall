﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ballRun : MonoBehaviour {
 
	private float  speed = 10.0f;
 
	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		var dir = Vector3.zero;
		float maxLimit = 3, minLimit = 360 - maxLimit;
		Quaternion rotRH = Input.gyro.attitude ;
		Vector3 vecrot = Input.gyro.rotationRateUnbiased;
		
 		// 現在の自信の回転の情報を取得する。
        Quaternion rot = new Quaternion(-rotRH.x, rotRH.z, -rotRH.y, rotRH.w) * Quaternion.Euler(0f, 180f, 0f);;
        // 合成して、自身に設定
        this.transform.rotation = rot;
		
		

        //X軸回転
        var localAngle = transform.localEulerAngles;
        if (localAngle.y > maxLimit && localAngle.y < 180)
            localAngle.y = maxLimit;
        if (localAngle.y < minLimit && localAngle.y > 180)
            localAngle.y = minLimit;
        transform.localEulerAngles = localAngle;
 
	}
}