using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
	//HingeJointコンポーネントを入れる
	private HingeJoint myHingeJoint;
	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();
		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
		TouchInfo info = AppUtil.GetTouch (AppUtil.touchCount);
		Vector3 position = AppUtil.GetTouchPosition (AppUtil.touchCount);

		if (info == TouchInfo.Began) {
			//左画面を押した時左フリッパーを動かす
			if (position.x < Screen.width * 0.5f && tag == "LeftFripperTag") {
				SetAngle (this.flickAngle);
			}
			//右画面
			if (position.x > Screen.width * 0.5f && tag == "RightFripperTag") {
				SetAngle (this.flickAngle);
			}
		}
			if(info == TouchInfo.Ended){
			//画面が離された時フリッパーを元に戻す
			if (position.x < Screen.width * 0.5f && tag == "LeftFripperTag") {
					SetAngle (this.defaultAngle);
			}
			if (position.x > Screen.width * 0.5f && tag == "RightFripperTag") {
					SetAngle (this.defaultAngle);
			}
		}
	}
		
	//フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}