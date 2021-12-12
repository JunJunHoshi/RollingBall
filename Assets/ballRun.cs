using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ballRun : MonoBehaviour {
 
	private float  speed = 10.0f;
	private Quaternion ori = default;
	// 現在速度
    private Vector3 _velocity;
	Rigidbody rigidbody;

 
	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
		ori = Input.gyro.attitude;
		_velocity = Vector3.zero;
		rigidbody = this.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		rigidbody.velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		var dir = Vector3.zero;
		float maxLimit = 3, minLimit = 360 - maxLimit;
		Quaternion rotRH = Input.gyro.attitude;
		Vector3 vecrot = Input.gyro.rotationRate;
		//Debug.Log(Input.gyro.rotationRate);
		rigidbody.velocity  = Vector3.zero;
		

		// 現在の自身の回転(rot)と開始時の回転(ori)との差分を取得し、それを回転情報と置く。
		//Quaternion rotDF = rotRH * Quaternion.Inverse(ori);
		//Quaternion rot = new Quaternion(-rotDF.x, 0f, -rotDF.y, rotDF.w);

		//計算した回転情報をUnityの世界座標系に合うように座標変換
		//rot = rot * Quaternion.Euler(0f, 0f, 0f);
		// 合成して、自身に設定
		//this.transform.localRotation = rot;
		//Debug.Log(Input.gyro.attitude.eulerAngles);
		
		// 加速度の時間積分から速度を求める
        rigidbody.angularVelocity = vecrot;

        // 速度の時間積分から位置を求める
        //this.GetComponent<Rigidbody>().angularVelocity += _velocity * Time.deltaTime;

        //X軸回転
        //var localAngle = transform.localEulerAngles;
        //if (localAngle.y > maxLimit && localAngle.y < 180)
        //    localAngle.y = maxLimit;
        //if (localAngle.y < minLimit && localAngle.y > 180)
        //    localAngle.y = minLimit;
        //transform.localEulerAngles = localAngle;
 
	}
}