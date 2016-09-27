using UnityEngine;
using System.Collections;

public class Motion : MonoBehaviour {
	public float speed;
	public bool active;
	// Use this for initialization
	void Start () {
		active = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 movement = new Vector2 (0f, -speed / 30f);
		this.transform.position = (Vector2)this.transform.position + movement;
	}
}
