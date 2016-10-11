using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public Transform target;
	float speed = 1;
	// Update is called once per frame
	void Update () 
	{
		float newx = Mathf.MoveTowards (this.transform.position.x, target.transform.position.x,0.05f);
		float newy = Mathf.MoveTowards (this.transform.position.y, target.transform.position.y, 0.05f);
		this.transform.position = new Vector2 (newx, newy);

	}
}
