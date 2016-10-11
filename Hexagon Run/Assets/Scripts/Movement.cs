using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	private string MovementAxisName;
	private float MovementInputValue;
	private string JumpAxisName;

	public float speed;
	public static Rigidbody2D rigid;

	private Vector2 posChange;
	private float xVel;
	private float lastXVel;
	private float yVel;
	private float lastYVel;

	// Use this for initialization
	void Start () {
		MovementAxisName = "Horizontal";
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		MovementInputValue = Input.GetAxis (MovementAxisName);
	}

	void FixedUpdate()
	{
		Move();
	}

	void Move()
	{
		posChange = new Vector2 (MovementInputValue * Time.deltaTime * speed, 0f);

		if(Mathf.Abs(rigid.position.x) > 24.3)
		{
			rigid.velocity = new Vector2 (-rigid.velocity.x, rigid.velocity.y);
			if (rigid.position.x < 0) {
				rigid.position = new Vector2(rigid.position.x + 0.5f,rigid.position.y);
			}

			if (rigid.position.x > 0) {
				rigid.position = new Vector2(rigid.position.x - 0.5f,rigid.position.y);
			}

		}

		rigid.velocity += posChange;
		rigid.rotation+= -3f* MovementInputValue;

	}

	public static void Jump(float strength)
	{
		rigid.velocity += (Vector2.up * strength);
	}

	public static bool IsOnGround()
	{
		RaycastHit2D[] hitDown = Physics2D.RaycastAll(rigid.transform.position, Vector3.down, 0.75f);

		for (int i = 0; i < hitDown.Length; i++) {
			if (hitDown [i].transform.tag.Equals ("Ground"))
			{
				return true;
			}
		}
			return false;
	}
		

	public static Vector2 GetMovement()
	{
		return rigid.velocity;
	}
}
