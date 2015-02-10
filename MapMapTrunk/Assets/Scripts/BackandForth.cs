using UnityEngine;
using System.Collections;

public class BackandForth : MonoBehaviour 
{
	//Moving
	public bool CanMove = false;
	public Vector3 pointB;
	public float MoveTime = 3.0f;
	//Scaling
	public float MaxScale = 0.5f;
	public float MinScale = 2.0f;
    
	private float targetScale;
	private Vector3 v3Scale;
	private Vector3 v3Scale2;
	IEnumerator Start()
	{
		v3Scale = transform.localScale; 
		//
		var pointA = transform.position;
		while (true) {
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, MaxScale, MoveTime));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, MinScale, MoveTime));
		}
	}
	
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float EndScale, float time)
	{
		v3Scale = new Vector3(EndScale, EndScale, EndScale);
		//
		var i= 0.0f;
		var rate= 1.0f/time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			if(CanMove)
			{
				thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			}
			transform.localScale = Vector3.Lerp(transform.localScale, v3Scale, i);
			yield return null; 
		}
	}
}
