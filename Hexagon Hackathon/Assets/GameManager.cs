using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private GameObject currShape;
	public GameObject prefab;
	private bool completed;
	private int x;

	int shape;
	public Transform startPosition;
	// Use this for initialization
	void Start () 
	{
		currShape = (GameObject)Instantiate (prefab,startPosition.position,startPosition.rotation);
		InvokeRepeating ("PlacePiece", 0f, 1f);

	}

	void PlacePiece()
	{
		if (!(currShape.GetComponent<ShapeBehavior> ().IsActive ())) 
		{
			currShape = Instantiate(prefab);
			RemoveCompletedRows();
		}
	}
		

	public void RemoveCompletedRows()
	{
		completed = true;
		for (x = -4; x < 21; x++) 
		{
			completed = true;
			for(int y = -4; y < 6; y++)
			{
				RaycastHit2D hit = Physics2D.Raycast ((new Vector2 (y, x)),new Vector2(0,1), 0.01f);
				if (!(hit.transform.tag.Equals ("Piece")))
				{
					completed = false;
				}

				if (completed == false) 
				{
					break;
				}
			}

			if (completed) 
			{
				for(int y = -4; y < 6; y++)
				{
					RaycastHit2D hit = Physics2D.Raycast ((new Vector2 (y, x)),new Vector2(0,1), 0.01f);
					Destroy(hit.transform.gameObject);
				}

			}
		}
	}

}
