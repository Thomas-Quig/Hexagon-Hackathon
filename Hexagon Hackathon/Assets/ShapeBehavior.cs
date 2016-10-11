using UnityEngine;
using System.Collections;

public class ShapeBehavior : MonoBehaviour {
	private string MovementAxisName;
	private int MovementInputValue;
	private bool active;
	public float speed = 3f;

	// Use this for initialization
	void Start () 
	{
		MovementAxisName = "Horizontal";
		InvokeRepeating ("MoveVert", 1f, 0.5f);
		InvokeRepeating ("MoveHoriz", 0f, 0.05f);
		active = true;
	}

	// Update is called once per frame

	void Update()
	{
		MovementInputValue = (int)Input.GetAxisRaw (MovementAxisName);
		Rotate ();
	}


/*	void MoveVert()
	{
		if (CheckMovement (Vector2.down)) 
		{
			this.transform.position += new Vector3 (0f, -0.433f);
		} 
		else 
		{
			active = false;
		}
	}
*/
	void MoveHoriz()
	{
		if (active) 
		{
			if (MovementInputValue != 0)
			{
				if (CheckMovement (new Vector2 (MovementInputValue, 0f))) 
				{ 
					this.transform.position += new Vector3 (MovementInputValue , 0f);
				}
			}
		}
	}

	void Rotate()
	{
		if (active) 
		{
			if (Input.GetKeyDown (KeyCode.Space)) {
				CheckTurning (); 
			}
		}

	}


	//Tester Methods
	bool CheckMovement(Vector2 direction)
	{
		bool moveable = true;
		PieceBehavior[] pieces = GetComponentsInChildren<PieceBehavior> ();
		for (int i = 0; i < pieces.Length; i++) {
			if (!(pieces [i].CanMove(direction))) 
			{
				moveable = false;
			}
		}
		return moveable;
	}

	void CheckTurning()
	{
		Transform firstRot = GetComponentInChildren<Transform> ();
		// Apply this rotation to the rigidbody's rotation.
		firstRot.rotation = firstRot.rotation * Quaternion.Euler (0f, 0f, -60f);
		bool moveable = true;
		PieceBehavior[] pieces = GetComponentsInChildren<PieceBehavior> ();
		for (int i = 0; i < pieces.Length; i++) {
			if (!(pieces [i].CanTurn())) 
			{
				moveable = false;
			}
		}
		if (moveable == false) {
			firstRot.rotation = firstRot.rotation * Quaternion.Euler (0f, 0f, 60f);
		}
	}

	public bool IsActive()
	{
		return active;
	}

}
