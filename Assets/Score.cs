using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	private GameObject scoreText;
	private int score = 0;

	// Use this for initialization
	void Start () {
		this.scoreText = GameObject.Find ("Score");
		this.scoreText.GetComponent<Text> ().text = "Score=0"; 
	}
	
	// Update is called once per frame
	void Update () {
		if (this.score > 0) {
			this.scoreText.GetComponent<Text> ().text = "Score=" + score;
		}
	}
		

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "SmallStarTag") {
			this.score += 10; 
			} else if (collision.gameObject.tag == "LargeStarTag") {
				this.score += 30; 
		    } else if (collision.gameObject.tag == "SmallCloudTag") {
				this.score += 20; 
		    } else if (collision.gameObject.tag == "LargeCloudTag") {
				this.score += 50; 
			}
	}
}
