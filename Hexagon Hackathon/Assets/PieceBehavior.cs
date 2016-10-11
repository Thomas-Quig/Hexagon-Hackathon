using UnityEngine;
using System.Collections;

public class PieceBehavior : MonoBehaviour {
	private bool moveable;
	// Use this for initialization
	void Start () {
		moveable = true;
	}

	public bool CanMove(Vector2 direction)
	{
		if (direction == Vector2.down)
		{
			RaycastHit2D[] hits1 = Physics2D.RaycastAll (this.transform.position + new Vector3(0,0.5f,0), direction, 0.51f);
			RaycastHit2D[] hits2 = Physics2D.RaycastAll (this.transform.position + new Vector3(0,-0.5f,0), direction, 0.51f);
			for (int i = 0; i < hits1.Length; i++) 
			{
				if (hits1[i].transform.tag.Equals ("Wall")) 
				{
					moveable = false;
					break;
				}

				if (hits1[i].transform.tag.Equals ("Piece") && hits1[i].transform.parent != this.transform.parent) 
				{
					moveable = false;
					break;
				}
			}
				for (int i = 0; i < hits2.Length; i++) 
				{
					if (hits2[i].transform.tag.Equals ("Wall")) 
					{
						moveable = false;
						break;
					}

					if (hits2[i].transform.tag.Equals ("Piece") && hits1[i].transform.parent != this.transform.parent) 
					{
						moveable = false;
						break;
					}
			}
		}
		else 
		{
			moveable = true;
			RaycastHit2D[] hits = Physics2D.RaycastAll (this.transform.position, direction, 0.51f);
			for (int i = 0; i < hits.Length; i++) 
			{
				if (hits[i].transform.tag.Equals ("Wall")) 
				{
					moveable = false;
					break;
				}

				if (hits [i].transform.tag.Equals ("Piece") && hits [i].transform.parent != this.transform.parent) 
				{
					moveable = false;
					break;
				}
			}
		}
		return moveable;
	}

	public bool CanTurn()
	{
		moveable = true;
		RaycastHit2D[] hits = Physics2D.RaycastAll (this.transform.position, new Vector2(0,0), 0.1f);
		for (int i = 0; i < hits.Length; i++) 
		{
			if (hits[i].transform.tag.Equals ("Wall")) 
			{
				moveable = false;
				break;
			}

			if (hits [i].transform.tag.Equals ("Piece") && hits [i].transform.parent != this.transform.parent) 
			{
				moveable = false;
				break;
			}
		}
		return moveable;
	}
}
