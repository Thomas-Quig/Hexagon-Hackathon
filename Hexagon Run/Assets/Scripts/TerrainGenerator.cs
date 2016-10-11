using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour {

	public GameObject prefab;
	public bool uniformPosition;
	public bool uniformScale;
	public bool uniformRotation;

	private int randomFactorPos = 1;
	private int randomFactorRot = 1;
	private int randomFactorScal = 1;
	// Use this for initialization
	void Start() 
	{
		if (uniformPosition) 
		{
			randomFactorPos = 0;
		}
		if (uniformRotation) {
			randomFactorRot = 0;
		}
		if (uniformScale) {
			randomFactorScal = 0;
		}

		for(int y = 40 ; y >= 4; y = y - 4 )
		{
				for(int x = -20 + (Random.Range(-2,4) * randomFactorPos); x <= 20 ; x = x + 5 + (Random.Range(0,5) * randomFactorPos))
				{
				GameObject currPlatform = Instantiate (prefab);
				//Position (changed within for look)
				currPlatform.transform.position = new Vector2(x,y + (Random.Range(0,2)* randomFactorPos));
				//Rotation (Changeable)
				currPlatform.transform.rotation = Quaternion.Euler(0,0,Random.Range (-30f, 30f) * randomFactorRot);
				//Scale (Can be changed)
				currPlatform.transform.localScale = new Vector2 (3 + (Random.Range (0, 2) *randomFactorScal), 1 + (Random.Range (0, 0.5f) * randomFactorScal));
				//Set Parent (Always Same)
				currPlatform.transform.parent = this.gameObject.transform;
				}
		}
	}

}
