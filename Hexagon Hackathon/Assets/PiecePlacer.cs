using UnityEngine;
using System.Collections;

//Just want to point out I put more effort into this code than anything in AP Comp Sci, like ever.
public class PiecePlacer : MonoBehaviour {
	private int lastNumber = 0; //Most recent number, will be opposite side of hexagon (to make sure it doesnt go out and back to previous place)
	private int number; 		//What side it is on, starting on top right side of hexagon and going clockwise
	public GameObject prefab;	//The prefab (Preset) object being instantiated every iteration through the loop
	public Transform originalPos;

	// Use this for initialization
	void Start () 
	{
		GameObject startingPiece = Instantiate(prefab);	//Creates the starting piece, spawned at (0,0) for the moment
		GameObject currPiece;							//The Current piece

		float red = Random.Range (0f,1f);				//Random Red color
		float green = Random.Range (0f, 1f);			//Random green color
		float blue = Random.Range (0f, 1f);				//Random blue color
	
		if(red == 1f && green == 1f && blue == 0.5f)		//If they are all 1, blue is 0.5 (because whatever)
		{
			blue = 0f;
		}
		Color pieceColor = new Color (red, green, blue, 1f);
	
		startingPiece.transform.position = originalPos.position;		//The position (in the transform variable) of starting piece is equal to (0,0) 
		startingPiece.transform.parent = this.gameObject.transform; //The parent of this piece is the transform (position) of this script
		startingPiece.gameObject.GetComponent<SpriteRenderer>().color = pieceColor;//Change the color
		Vector2 lastPos = originalPos.position;						//The lastPos, or last position, or most recent position.

		for (float i = 0f; i < 3f; i++) //Go through this array 3 more times, on top of the first, that makes four total
		{
			
			currPiece = Instantiate (prefab);	//Instantiates a new piece, with the name of Piece(1/2/3/4) depending.
			string name = "Piece" + i;

			number = Random.Range(1,6);		//Picks a random number inbetween 1 and 6
			while (number == lastNumber)	//If it wasnt the opposite direction of the most recent extension, keep picking a number
			{
				number = Random.Range (1, 6);	//Pick new random number
			}

			if (number == 1) 
			{
				currPiece.name = name;													//Change name 
				currPiece.gameObject.GetComponent<SpriteRenderer>().color = pieceColor;	//Change color
				currPiece.transform.position = (new Vector2 (-0.75f, 0.433f) + lastPos);//Change position based on previous position
				currPiece.transform.parent = this.gameObject.transform;	//Set parent to the shape object
				lastNumber = 4;											//1 + 3 is 4, opposite side of the hexagon... Dont think about this.
			} 

			if (number == 2) //Different side, same concept
			{
				currPiece.name = name;
				currPiece.gameObject.GetComponent<SpriteRenderer>().color = pieceColor;
				currPiece.transform.parent = this.gameObject.transform;
				currPiece.transform.position = (new Vector2 (0f, 0.866f) + lastPos);

				lastNumber = 5;
			}

			if (number == 3) 
			{
				currPiece.name = name;
				currPiece.gameObject.GetComponent<SpriteRenderer>().color = pieceColor;
				currPiece.transform.position = (new Vector2 (0.75f, 0.433f) + lastPos);
				currPiece.transform.parent = this.gameObject.transform;
				lastNumber = 6;
			}

			if (number == 4) 
			{
				currPiece.name = name;
				currPiece.gameObject.GetComponent<SpriteRenderer>().color = pieceColor;
				currPiece.transform.position = (new Vector2 (-0.75f, 0.433f) + lastPos);
				currPiece.transform.parent = this.gameObject.transform;
				lastNumber = 1;
			}

			if (number == 5) 
			{
				currPiece.name = name;
				currPiece.gameObject.GetComponent<SpriteRenderer>().color = pieceColor;
				currPiece.transform.parent = this.gameObject.transform;
				currPiece.transform.position = (new Vector2 (0f, -0.866f) + lastPos);

				lastNumber = 2;
			}
			if (number == 6) 
			{
				currPiece.name = name;
				currPiece.gameObject.GetComponent<SpriteRenderer>().color = pieceColor;
				currPiece.transform.position = (new Vector2 (-0.75f, -0.433f) + lastPos);
				currPiece.transform.parent = this.gameObject.transform;
				lastNumber = 3;
			}
			lastPos = currPiece.transform.position;	//Set the last piece to 
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
