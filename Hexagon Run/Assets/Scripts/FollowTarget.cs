using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {
	public Transform target;
	public bool matchPosition;
	public bool matchRotation;
	public bool matchScale;
	public bool scaleZoom;
	// Use this for initialization
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (matchPosition) {
			//this.transform.position = new Vector2 (target.transform.position.x - (target.transform.position.x % 0.05f),target.transform.position.y - (target.transform.position.y % 0.05f));
			this.transform.position = target.transform.position;
		}
		if (matchRotation) {
			this.transform.rotation = target.transform.rotation;
		}
		if (matchScale) {
			this.transform.localScale = target.transform.localScale;
		}
		if (scaleZoom) {
			Camera cam = this.GetComponentInChildren<Camera> ();
			cam.orthographicSize = Mathf.Max(3,Mathf.MoveTowards(cam.orthographicSize,(Mathf.Abs(Movement.GetMovement ().x) + Mathf.Abs(Movement.GetMovement().y)), Time.deltaTime * 2.0f));
		}
	}
}
