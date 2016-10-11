using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Charge : MonoBehaviour {
	public float MinLaunchForce; 
	public float MaxLaunchForce; 
	public float MaxChargeTime;


	private string JumpButton;         
	private float CurrentLaunchForce;  
	private float ChargeSpeed;         
	private bool Jumped;                

	public SpriteRenderer picture;
	// Use this for initialization
	private void OnEnable()
	{
		CurrentLaunchForce = MinLaunchForce;

	}

	void Start () {
		JumpButton = "Jump";
		ChargeSpeed = (MaxLaunchForce - MinLaunchForce) / MaxChargeTime;
		picture = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Movement.IsOnGround ())
		{
			if (CurrentLaunchForce >= MaxLaunchForce && !Jumped)
			{
				CurrentLaunchForce = MaxLaunchForce;
				Movement.Jump (CurrentLaunchForce);
				Jumped = true;
				picture.color = Color.white;
				CurrentLaunchForce = MinLaunchForce;
			}
			else if (Input.GetButtonDown (JumpButton))
			{
				Jumped = false;
				CurrentLaunchForce = MinLaunchForce;
			} 
			else if (Input.GetButton (JumpButton) && !Jumped) 
			{
					CurrentLaunchForce += ChargeSpeed * Time.deltaTime;
			} 
			else if (Input.GetButtonUp (JumpButton) && !Jumped) 
			{
				Movement.Jump (CurrentLaunchForce);
				Jumped = true;
				picture.color = Color.white;
				CurrentLaunchForce = MinLaunchForce;
			}
			if (CurrentLaunchForce != MinLaunchForce) 
			{
				picture.color = Color.Lerp (Color.green , Color.red, (CurrentLaunchForce / MaxLaunchForce));
			}
				
		}
		else 
		{
			picture.color = Color.white;
		}
	}
}
