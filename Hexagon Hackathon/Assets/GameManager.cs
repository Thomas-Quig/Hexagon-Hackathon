using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject prefab;
	private GameObject firstShape;
	private GameObject currShape;
	// Use this for initialization

	void Start ()
	{
		firstShape = Instantiate (prefab);
		currShape = firstShape;
		InvokeRepeating ("SummonNewShape", 0f, 1f);

	}
			
	void SummonNewShape()
	{
		if (!(currShape.GetComponent<ShapeBehavior>().isActive())) 
		{
			currShape = Instantiate (prefab);
		}
	}
			

}
