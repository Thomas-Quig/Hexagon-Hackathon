using UnityEngine;
using System.Collections;

public class ShapeBehavior : MonoBehaviour {
	private string MovementAxisName;
	private float MovementInputValue;
	private Rigidbody2D rigid;
	// Use this for initialization
	void Start () 
	{
		MovementAxisName = "Horizontal";
		this.enabled = true;
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
		rigid.velocity = new Vector2 (4.5f * MovementInputValue,rigid.velocity.y);
	}

	private void Turn()
	{
		Transform firstRot = GetComponentInChildren<Transform> ();
		// Apply this rotation to the rigidbody's rotation.
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			firstRot.rotation = firstRot.rotation * Quaternion.Euler(0f,0f,60f );
		}

	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag.Equals("Wall") || col.gameObject.tag.Equals("Piece"))
			{
			this.enabled = false;
			this.gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}
	}

	public bool isActive()
	{
		return this.enabled;
	}

}
