using UnityEngine;
using System.Collections;

public class IconAnimator : MonoBehaviour 
{
	public float speed = 0.1f;
	public float MaxSize = 0.0f;
	public float MinSize = 0.0f;
	public float x,y,z;
	public float maxScale = 0.5f;
	public float minScale = 2.0f;
	public float shrinkSpeed = 1.0f;    
	
	private float targetScale;
	private Vector3 v3Scale;
	// Use this for initialization
	void Start () 
	{
		v3Scale = transform.localScale; 
		GeneratedPosition();
		transform.localScale.Equals(Random.Range(MinSize,MaxSize));
	}
	Vector3 GeneratedPosition()
	{

		x = Random.Range(MinSize,MaxSize);
		y = Random.Range(MinSize,MaxSize);
		z = Random.Range(MinSize,MaxSize);
		return new Vector3(x,y,z);
	}

	void Shrink()
	{
		targetScale = minScale;
		v3Scale = new Vector3(targetScale, targetScale, targetScale);
		if(v3Scale.x == minScale)
		{
			//Grow();
		}
	}

	void Grow()
	{
		targetScale = maxScale;
		v3Scale = new Vector3(targetScale, targetScale, targetScale);
		if(v3Scale.x == maxScale)
		{
			//Shrink();
		}
	}
	// Update is called once per frame
	void Update () 
	{
	
		Shrink();
		transform.localScale = Vector3.Lerp(transform.localScale, v3Scale, Time.deltaTime*shrinkSpeed);
	
	}
}
