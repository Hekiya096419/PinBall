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

	private int leftFingerId = 0;
	private int rightFingerId = 0;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();
		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			Touch[] touches = Input.touches;
			for (int i = 0; i < Input.touchCount; i++) {
				Touch touch = Input.GetTouch (i);

				if (touch.phase == TouchPhase.Began) {
					if (touch.position.x < Screen.width * 0.5f && tag == "LeftFripperTag") {
						SetAngle (this.flickAngle);
						leftFingerId = Input.touches [i].fingerId;
					}else if (touch.position.x > Screen.width * 0.5f && tag == "RightFripperTag") {
						SetAngle (this.flickAngle);
						rightFingerId = Input.touches [i].fingerId;
					}
				}else if (touch.phase == TouchPhase.Ended) {
					//画面が離された時フリッパーを元に戻す
					if (touch.fingerId == leftFingerId && tag == "LeftFripperTag") {
						SetAngle (this.defaultAngle);
						leftFingerId = -1;
					}else if (touch.fingerId == rightFingerId && tag == "RightFripperTag") {
						SetAngle (this.defaultAngle);
						rightFingerId = -1;
					}
				}
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