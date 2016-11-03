using UnityEngine;
using System.Collections;

public class DragonController : MonoBehaviour 
{
	public Rigidbody dragonRigidbody;

	public float Momentspeed = 0.0f;

	public float throttle = 40f;
	public float fallSpeed = 50f;
	public float maxSpeed = 150f;
	public bool sideMoveRotates;
	public float rotationSpeed = 1f;
	public bool disableForwardMove;
	public bool disableSideMove;
	public bool disableVerticalMove;
	public float staticDrag = 0.5f;
	public float dynamicDrag = 0.3f;

	[Space(15)]
	public AudioSource soundSource;
	public AudioClip throttleSound;
	public AudioClip idleSound;
	public GameObject spotShadow;
	public LayerMask spotShadowSurface;

	[Space(15)]
	public bool useDash;
	public float dashSpeed = 500f;
	public float dashInterval = 0.2f;
	public bool allowVerticalDash = true;
	public AudioClip dashSound;

	[Space(15)]
	public bool useFuel;
	public float maxFuelSupply = 300f;
	public float fuelSupply = 300f;
	public float fuelRecharge = 1f;
	public float moveCost = 1f;
	public float dashCost = 50f;
	public bool fuelCostOnVerticalMove = true;
	public float fuelNeeded = 70f;

	private GameObject dashMarker;
	private float SideMove;
	private float ForwardMove;
	private float VerticalMove;
	private Vector3 moveDirection;
	private Vector3 facingDirection;
	private Vector3 sideDirection;
	private Vector3 verticalDirection;
	private Vector3 dashDirection;
	
	private int inputCount;
	private float fullSpeed;
	private float halfSpeed;
	private float thirdSpeed;
	private float tempVelocity;
	private float tempThrottle;
	private GameObject spot;
	private RaycastHit spotHit;
	private Vector3 spotPoint;
	private bool dashBool;
	private bool dashReady = true;
	private bool fuelDepleted;
	private bool drainFuel;
	private bool rechargeFuel;

	//private Vector3 movedeDirection = Vector3.zero;
	Vector3 lastPosition = Vector3.zero;


	void Start()
	{
		fullSpeed = throttle;					
		halfSpeed = throttle * 0.707106682f; //Allows for diagonal move speed. DO NOT MODIFY NUMBER

		Momentspeed = (this.transform.position - lastPosition).magnitude;
		lastPosition = this.transform.position;

		if (spotShadow != null) 
		{
			spot = Instantiate(spotShadow, dragonRigidbody.transform.position, dragonRigidbody.transform.rotation) as GameObject;
			spot.transform.parent = dragonRigidbody.transform;
		}

		if (useDash == true) 
		{
			dashMarker = new GameObject("Dash Direction Marker");
			dashMarker.transform.parent = dragonRigidbody.transform;
			dashMarker.transform.position = dragonRigidbody.transform.position;
			dashMarker.transform.rotation = dragonRigidbody.transform.rotation;
		}

		if (soundSource != null && idleSound != null) 
		{
			soundSource.clip = idleSound;
			soundSource.Play();
		}
	}
	
	void FixedUpdate () 
	{
		if (drainFuel) 
		{
			fuelSupply -= moveCost;
			if (fuelSupply < 0) 
			{
				fuelDepleted = true;
				fuelSupply = 0;
			}
		}

		if (rechargeFuel) 
		{
			fuelSupply += fuelRecharge;
			if (fuelSupply >= fuelNeeded) 
			{
				fuelDepleted = false;
			}
		}
	
		if (disableForwardMove == false) 
		{
			dragonRigidbody.AddForce (facingDirection * throttle, ForceMode.Acceleration);
		}

		if (disableSideMove == false) 
		{
			if (!sideMoveRotates) 
			{
				dragonRigidbody.AddForce (sideDirection * throttle, ForceMode.Acceleration);
			}

			if (sideMoveRotates) 
			{
				dragonRigidbody.transform.localRotation = dragonRigidbody.transform.localRotation * Quaternion.Euler (0, SideMove * rotationSpeed, 0);
			}
		}

		if (disableVerticalMove == false) 
		{
			dragonRigidbody.AddForce (verticalDirection * throttle, ForceMode.Acceleration);
		}

		if (!Input.GetButton ("VerticalMove") && (disableVerticalMove == false)) 
		{
			dragonRigidbody.AddForce (-Vector3.up * fallSpeed, ForceMode.Acceleration);
		}

		if (dashBool && dashReady) 
		{
			dashDirection = dashMarker.transform.position - dragonRigidbody.transform.position;
			dragonRigidbody.velocity = Vector3.zero;
			dragonRigidbody.AddForce(dashDirection * dashSpeed, ForceMode.Acceleration);
			dashBool = false;
			dashReady = false;
		}
	}
	
	void Update()
	{
		//Base Movement
		if (disableSideMove == false) 
		{
			SideMove = (Input.GetAxis ("SideMove"));
		} 
		else 
		{
			SideMove = 0;
		}

		if (disableForwardMove == false) 
		{
			ForwardMove = (Input.GetAxis ("ForwardMove"));
		} 
		else 
		{
			ForwardMove = 0;
		}

		if (disableVerticalMove == false) 
		{
			VerticalMove = (Input.GetAxis ("VerticalMove"));
		} 
		else 
		{
			VerticalMove = 0;
		}
		

		//Fuel for Jumping/Flying
		if (useFuel) 
		{
			if (!fuelCostOnVerticalMove) 
			{
				if ((Input.GetAxisRaw ("ForwardMove") != 0 || Input.GetAxis ("SideMove") != 0 || Input.GetAxis ("VerticalMove") != 0) && (fuelDepleted == false)) 
				{
					rechargeFuel = false;
					drainFuel = true;
				}
			}

			if (fuelCostOnVerticalMove)
			{
				if ((Input.GetAxis ("VerticalMove") != 0) && (fuelDepleted == false)) 
				{
					drainFuel = true;
					rechargeFuel = false;
				}
			}

			if (fuelCostOnVerticalMove) 
			{
				if (Input.GetAxisRaw ("VerticalMove") == 0 || fuelDepleted) 
				{
					drainFuel = false;
					rechargeFuel = true;
				}
			}

			if (!fuelCostOnVerticalMove) 
			{
				if ((Input.GetAxisRaw ("VerticalMove") == 0 && Input.GetAxisRaw ("SideMove") == 0 && Input.GetAxisRaw ("ForwardMove") == 0) || fuelDepleted) 
				{
					drainFuel = false;
					rechargeFuel = true;
				}
			}
		}


		//Speed
		if (throttle != tempThrottle) 
		{
			fullSpeed = throttle;
			halfSpeed = throttle * 0.707106682f; //Allows for diagonal move speed. DO NOT MODIFY NUMBER    	
		}

		if (spotShadow != null) 
		{
			if (Physics.Raycast(dragonRigidbody.transform.position, -dragonRigidbody.transform.up, out spotHit, 100000, spotShadowSurface))
			{
				spot.SetActive(true);
				spotPoint = new Vector3(spotHit.point.x, spotHit.point.y + 0.05f, spotHit.point.z);
				spot.transform.position = spotPoint;
				spot.transform.eulerAngles = Vector3.zero;
			}
			else
			{
				spot.SetActive(false);
			}
		}
		
				
		//Suppress Drag when Moving
		if (SideMove == 0 && VerticalMove == 0 && ForwardMove == 0) 
		{
			dragonRigidbody.drag = staticDrag;
		} 
		else 
		{
			dragonRigidbody.drag = dynamicDrag;
		}
		
				
		//Speed Regulator for Multiple Player Input
		if (Input.GetButtonDown("SideMove") && disableSideMove == false)
		{
			inputCount += 1;
		}

		if (Input.GetButtonUp("SideMove") && disableSideMove == false)
		{
			inputCount -= 1;
		}

		if (Input.GetButtonDown("ForwardMove") && disableForwardMove == false)
		{
			inputCount += 1;
		}

		if (Input.GetButtonUp("ForwardMove") && disableForwardMove == false)
		{
			inputCount -= 1;
		}

		if (inputCount == 0 || inputCount == 1)
		{
			throttle = fullSpeed;
		}

		if (inputCount == 2)
		{
			throttle = halfSpeed;
		}


		//Sound Effects Control
		if ((inputCount > 0 || Input.GetAxisRaw("VerticalMove") == 1 || Input.GetAxisRaw("VerticalMove") == -1) && 
			(!useFuel || !fuelDepleted) && soundSource != null && throttleSound != null && soundSource.isPlaying == false && idleSound == null) 
		{
			soundSource.clip = throttleSound;
			soundSource.Play();
		}

		if ((inputCount > 0 || Input.GetAxisRaw("VerticalMove") == 1 || Input.GetAxisRaw("VerticalMove") == -1) && 
			(!useFuel || !fuelDepleted) && soundSource != null && throttleSound != null  && idleSound != null && soundSource.clip != throttleSound) 
		{
			soundSource.clip = throttleSound;
			soundSource.Play();
		}

		if (inputCount == 0 && Input.GetAxisRaw ("VerticalMove") == 0 && soundSource != null && idleSound != null && soundSource.clip != idleSound) 
		{
			soundSource.clip = idleSound;
			soundSource.Play();
		}

		if (inputCount == 0 && Input.GetAxisRaw ("VerticalMove") == 0 && soundSource != null && idleSound == null && soundSource.isPlaying == true) 
		{
			soundSource.Stop ();
		}

		
		//Fuel Control when Empty
		if ((!useFuel) || fuelDepleted == false) 
		{
			facingDirection = dragonRigidbody.transform.forward * ForwardMove;
			sideDirection = dragonRigidbody.transform.right * SideMove;
			verticalDirection = Vector3.up * VerticalMove; 
		}

		if (useFuel && fuelDepleted && !fuelCostOnVerticalMove) 
		{
			facingDirection = Vector3.zero ;
			sideDirection = Vector3.zero;
			verticalDirection = Vector3.zero ; 
		}

		if (useFuel && fuelDepleted && fuelCostOnVerticalMove) 
		{
			facingDirection = dragonRigidbody.transform.forward * ForwardMove;
			sideDirection = dragonRigidbody.transform.right * SideMove;
			verticalDirection = Vector3.zero ; 
		}

		if (dragonRigidbody.velocity.magnitude > maxSpeed)
		{
			dragonRigidbody.velocity = dragonRigidbody.velocity.normalized * maxSpeed;
		}
		

		// Dash Jump Indicator
		if (SideMove == 0 && dashMarker != null) 
		{
			dashMarker.transform.localPosition = new Vector3(0,dashMarker.transform.localPosition.y,dashMarker.transform.localPosition.z);  
		}

		if (SideMove == 1 && dashMarker != null) 
		{
			dashMarker.transform.localPosition = new Vector3(5,dashMarker.transform.localPosition.y,dashMarker.transform.localPosition.z);  
		}

		if (SideMove == -1 && dashMarker != null)  
		{
			dashMarker.transform.localPosition = new Vector3(-5,dashMarker.transform.localPosition.y,dashMarker.transform.localPosition.z);  
		}
		
		if (ForwardMove == 0 && dashMarker != null) 
		{
			dashMarker.transform.localPosition = new Vector3(dashMarker.transform.localPosition.x,dashMarker.transform.localPosition.y,0);
		}

		if (ForwardMove == 1 && dashMarker != null) 
		{
			dashMarker.transform.localPosition = new Vector3(dashMarker.transform.localPosition.x,dashMarker.transform.localPosition.y,5);
		}

		if (ForwardMove == -1 && dashMarker != null) 
		{
			dashMarker.transform.localPosition = new Vector3(dashMarker.transform.localPosition.x,dashMarker.transform.localPosition.y,-5);
		}
			
		if (allowVerticalDash) 
		{
			if (VerticalMove == 0 && dashMarker != null) 
			{
				dashMarker.transform.localPosition = new Vector3 (dashMarker.transform.localPosition.x, 0, dashMarker.transform.localPosition.z);
			}

			if (VerticalMove == 1 && dashMarker != null) 
			{
				dashMarker.transform.localPosition = new Vector3 (dashMarker.transform.localPosition.x, 5, dashMarker.transform.localPosition.z);
			}

			if (VerticalMove == -1 && dashMarker != null) 
			{
				dashMarker.transform.localPosition = new Vector3 (dashMarker.transform.localPosition.x, -5, dashMarker.transform.localPosition.z);
			}
		}

		if (Input.GetButtonDown ("Dash") && dashMarker != null && dashReady == true && dashMarker.transform.position != dragonRigidbody.transform.position) 
		{
			if ((useFuel && fuelSupply >= dashCost) || (!useFuel)) 
			{
				if (allowVerticalDash == true) 
				{
					if (inputCount > 0 || Input.GetAxis ("VerticalMove") != 0) 
					{
						dashBool = true;
						StartCoroutine ("DashCooldownFunction");
						soundSource.PlayOneShot(dashSound);
					}
				}

				if (allowVerticalDash == false) 
				{
					if (Input.GetAxis ("VerticalMove") == 0) 
					{
						dashBool = true;
						StartCoroutine ("DashCooldownFunction");
						soundSource.PlayOneShot(dashSound);
					}
				}

				if (useFuel) 
				{
					fuelSupply -= dashCost;
					if (fuelSupply < 0) 
					{
						fuelSupply = 0;
					}
				}
			}
		}

		tempThrottle = throttle;

		if (fuelSupply > maxFuelSupply) 
		{
			fuelSupply = maxFuelSupply;
		}
	} 	
	public float GetPlayerFastness(){
		return Momentspeed;
	}

	IEnumerator DashCooldownFunction()
	{
		yield return new WaitForSeconds(dashInterval);
		dashReady = true;
	}
}