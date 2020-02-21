using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AppUtil{
	private static Vector3 TouchPosition = Vector3.zero;
	private static Vector3 PreviousPosition = Vector3.zero;

	public static int touchCount {
		get {
			if (Application.isEditor) {
				if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonUp (0)) {
					return 1;
				} else {
					return 0;
				}
			} else {
				return Input.touchCount;
			}
		}
	}
			
	public static TouchInfo GetTouch(int i){
		if (Application.isEditor) {
			if (Input.GetMouseButtonDown (0)) {
				return TouchInfo.Began;
			}
			if (Input.GetMouseButtonUp (0)) {
				return TouchInfo.Ended;
			} 
		}else {
			if (Input.touchCount >= i) {
					return(TouchInfo)((int)Input.GetTouch (i).phase);
				}
			}
			return TouchInfo.None;
		}
	
	public static Vector3 GetTouchPosition(int i){
		if (Application.isEditor) {
			TouchInfo touch = AppUtil.GetTouch (i);
			if (touch != TouchInfo.None) {
				PreviousPosition = Input.mousePosition; 
				return PreviousPosition;
			}
		} else {
			if (Input.touchCount > i){
				Touch touch = Input.GetTouch (i);
				TouchPosition.x = touch.position.x;
				TouchPosition.y = touch.position.y;
				return TouchPosition;
				}
			}
			return Vector3.zero;
		}

	public static Vector3 GetDeltaPosition(int i){
		if(Application.isEditor){
			TouchInfo info = AppUtil.GetTouch (i);
			if(info != TouchInfo.None){
				Vector3 currentPosition = Input.mousePosition;
				Vector3 delta = currentPosition - PreviousPosition;
				PreviousPosition = currentPosition;
				return delta;
			}
		}else{
			if(Input.touchCount >= i){
				Touch touch = Input.GetTouch (i);
				PreviousPosition.x = touch.deltaPosition.x;
				PreviousPosition.y = touch.deltaPosition.y;
				return PreviousPosition;
			}
		}
		return Vector3.zero;
	}

	public static int GetFingerId(int i){
		if(Application.isEditor){
			if(Input.GetMouseButtonDown (0) || Input.GetMouseButtonUp (0)) {
				return 1;
			} else {
				return 0;
			}
		} else {
			return Input.GetTouch(i).fingerId;
		}
	}

	public static Vector3 GetTouchWorldPostion(Camera camera, int i){
		return camera.ScreenToWorldPoint (GetTouchPosition (i));
	}
}

public enum TouchInfo{
	None = 99,
	Began = 0,
	Ended = 3,
}
