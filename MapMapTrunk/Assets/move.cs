//using UnityEngine;
//using System.Collections;
//
//public class move : MonoBehaviour {
//	public float journeyLength;
//	public float startTime = 1.0f;
//	public float Speed = 5.0f;
//	public float waitTime = 2.0f;
//	public float distCovered = (Time.time - waitTime) * speed;
//	public float fracJourney = distCovered / journeyLength;
//	public Transform StartPt;
//	public Transform EndPt;
//	// additional data members beyond Vector3.Lerp's documentation
//	public float PauseTime = 2.0f;
//	int direction_ = 1;
//	bool doPause_ = false;
//	
//	void Update(){
//		float elapsedTime = Time.time - startTime;
//		
//		//  if the elapsed time has exceeded the pause time and we're paused
//		//  unpause and reset the startTime;
//		if(elapsedTime > PauseTime && doPause_){
//			doPause_ = false;
//			startTime = Time.time;
//		}
//	}
//	void FixedUpdate(){
//		if(doPause_)return;
//		
//		float distCovered = (Time.time - startTime) * Speed;
//		float fracJourney = distCovered / journeyLength;
//		
//		// +direction means we are going from [0,1], -direction means [1,0]
//		fracJourney = (direction_>0)?fracJourney:1.0f-fracJourney;
//		transform.position = Vector3.Lerp(StartPt.position, EndPt.position, fracJourney);
//		
//		// When fracJourney is not in [0,1], flip direction and pause
//		if(fracJourney > 1.0 || fracJourney < 0.0){
//			direction_ = -direction_;
//			startTime = Time.time;
//			doPause_ = true;
//		}
//	}
//}
