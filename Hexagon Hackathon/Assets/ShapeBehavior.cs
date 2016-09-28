using UnityEngine;
using System.Collections;

public class ShapeBehavior : MonoBehaviour {
	private string MovementAxisName;
	private bool enabled;
	private float MovementInputValue;
	private Rigidbody2D rigid;
	// Use this for initialization
	void Start () 
	{
		MovementAxisName = "Horizontal";
		enabled = true;
		rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	private void Update ()
	{
		MovementInputValue = Input.GetAxis (MovementAxisName);
	}

	private void FixedUpdate()
	{
		if (enabled) 
		{
			Move ();
			Turn ();
		}
	
	}

	private void Move()
	{
		rigid.velocity = new Vector2 (4.5f * MovementInputValue,0);
	}

	private void Turn()
	{
		Transform firstRot = GetComponentInChildren<Transform> ();
		// Apply this rotation to the rigidbody's rotation.
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			firstRot.rotation = firstRot.rotation * Quaternion.Euler(0f,0f,90f );
		}

	}

	private void OnCollisionEnter2D(Collider2D col)
	{
		if(col.gameObject.tag.Equals("Wall"))
			{
				enabled = false;
			}
	}

}
