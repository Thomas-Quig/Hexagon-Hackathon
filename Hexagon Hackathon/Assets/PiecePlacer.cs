using UnityEngine;
using System.Collections;

public class PiecePlacer : MonoBehaviour {
	private int lastNumber = 0;
	private int number;
	public GameObject prefab;
	// Use this for initialization
	void Start () 
	{
		GameObject startingPiece = Instantiate(prefab);
		GameObject currPiece;
	
		startingPiece.transform.position = new Vector2(0f, 0f);
		startingPiece.transform.parent = this.gameObject.transform;
	
		Vector2 lastPos = new Vector2(0f,0f);
		for (float i = 0f; i < 3f; i++) 
		{
			
			currPiece = Instantiate (prefab);
			string name = "Piece" + i;

			number = Random.Range (1, 7);
			while (number == lastNumber)
			{
				number = Random.Range (1, 7);
			}

			if (number == 1) 
			{
				currPiece.name = name;
				currPiece.transform.position = (new Vector2 (-0.75f, 0.433f) + lastPos);
				currPiece.transform.parent = this.gameObject.transform;
				lastNumber = 4;
			} 

			if (number == 2) 
			{
				currPiece.name = name;
				currPiece.transform.parent = this.gameObject.transform;
				currPiece.transform.position = (new Vector2 (0f, 0.866f) + lastPos);

				lastNumber = 5;
			}

			if (number == 3) 
			{
				currPiece.name = name;
				currPiece.transform.position = (new Vector2 (0.75f, 0.433f) + lastPos);
				currPiece.transform.parent = this.gameObject.transform;
				lastNumber = 6;
			}

			if (number == 4) 
			{
				currPiece.name = name;
				currPiece.transform.position = (new Vector2 (-0.75f, 0.433f) + lastPos);
				currPiece.transform.parent = this.gameObject.transform;
				lastNumber = 1;
			}

			if (number == 5) 
			{
				currPiece.name = name;
				currPiece.transform.parent = this.gameObject.transform;
				currPiece.transform.position = (new Vector2 (0f, 0.866f) + lastPos);

				lastNumber = 2;
			}
			if (number == 6) 
			{
				currPiece.name = name;
				currPiece.transform.position = (new Vector2 (-0.75f, -0.433f) + lastPos);
				currPiece.transform.parent = this.gameObject.transform;
				lastNumber = 3;
			}
			lastPos = currPiece.transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
