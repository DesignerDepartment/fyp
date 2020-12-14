using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
	public float walkingSpeed = 7.5f; 
	public float runningSpeed = 11.5f; 
	public float jumpSpeed = 8.0f; 
	public float gravity = 20.0f; 
	public Camera playerCamera;
	public float lookSpeed = 2.0f;
	public float lookXLimit = 45.0f;
	public float range;


	public INTR_Sabun oldSabun = null;
	public INTR_Gayung oldGayung = null;
	public INTR_Sugi oldSugi = null;
	public INTR_SarungTangan oldSarungTangan = null;
	public INTR_Kapas oldKapas = null;
	public INTR_Baldi oldAir = null;
	public INTR_Gayung air = null;

	public Arrow red = null;

	public INTR_Corpse Ebutton = null;



	CharacterController characterController; 
	Vector3 moveDirection = Vector3.zero; 
	float rotationX = 0;

	//animator
	public AnimationTangan kanan;
	public AnimationBody cedok;

	//Full
	public bool not_full = true;

	//ambilAir
	public bool ambilAir = false;


	//ambikAir
	private Animator body;

	[HideInInspector]
	public bool canMove = true;

	//curah air
	[SerializeField] private Animator curah;
	[SerializeField] private Animator cedokAirBersih;
	ParticleSystem myWater;
	public Spill spill;

	void Start()
	{
		characterController = GetComponent<CharacterController>();

		// Lock cursor
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		body = GetComponent<Animator>();

		myWater = GetComponent<ParticleSystem>();


	}

	void Update()
	{

		showTextSabun();
		showTextGayung();
		showTextSugi();
		showTextGlove();
		showTextKapas();
		//redToGreen();
		showTextAir();
		showbuttonE();


		if (Input.GetButton("Fire1") )
		{
			interactItem();
		}

		if (Input.GetButton("Fire2"))
		{
			release();
		}

		if (Input.GetButton("Fire2"))
		{
			cedokAir();
			
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			curah.SetBool("ambilAir", false);
			curah.SetBool("curah", true);
			curah.SetBool("Grabbed", true);
			spill.spill();
			//curahAir();
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			
			curah.SetBool("curah", false);
			spill.Stopspill();
			//curahAir();
		}












		// We are grounded, so recalculate move direction based on axes

		Vector3 forward = transform.TransformDirection(Vector3.forward);
		Vector3 right = transform.TransformDirection(Vector3.right);
		
		// Press Left Shift to run
		
		bool isRunning = Input.GetKey(KeyCode.LeftShift);
		float curSpeedX = canMove ? (isRunning ? runningSpeed :walkingSpeed) * Input.GetAxis("Vertical") : 0;
		float curSpeedY = canMove ? (isRunning ? runningSpeed :walkingSpeed) * Input.GetAxis("Horizontal") : 0;
		float movementDirectionY = moveDirection.y;
		moveDirection = (forward * curSpeedX) + (right * curSpeedY);

		if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
		{
			UnityEngine.Debug.Log("Hello: ");

		}
		else
		{

			moveDirection.y = jumpSpeed;
			moveDirection.y = movementDirectionY;

		}

		// Apply gravity. Gravity is multiplied by deltaTime twice(once here, and once below
		// when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
		// as an acceleration (ms^-2)
		if (!characterController.isGrounded)
		{
			moveDirection.y -= gravity * Time.deltaTime;
		}

		// Move the controller 
		characterController.Move(moveDirection * Time.deltaTime);

		// Player and Camera rotation 
		if (canMove)
		{
			rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
			rotationX = Mathf.Clamp(rotationX, -lookXLimit,lookXLimit);
			playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
			transform.rotation *= Quaternion.Euler(0,Input.GetAxis("Mouse X") * lookSpeed, 0);
		}
	}

	public void showTextSabun() {

		RaycastHit detect;

		UnityEngine.Debug.Log("NamaSabun");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range)) {

			INTR_Sabun sabun = detect.transform.GetComponent<INTR_Sabun>();
			if (sabun != null)
			{
				oldSabun = sabun;
				sabun.showText();
			}
			else oldSabun.unshowText();
		}
	}

	public void showTextGayung()
	{

		RaycastHit detect;

		UnityEngine.Debug.Log("NamaGayung");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{

			INTR_Gayung gayung = detect.transform.GetComponent<INTR_Gayung>();
			if (gayung != null)
			{
				oldGayung = gayung;
				gayung.showTextGayung();
			
			}
			else
			{
				oldGayung.unshowTextGayung();
			}
				
		}
	}

	public void showTextSugi()
	{

		RaycastHit detect;

		UnityEngine.Debug.Log("NamaSugi");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{

			INTR_Sugi sugi = detect.transform.GetComponent<INTR_Sugi>();
			if (sugi != null)
			{
				oldSugi = sugi;
				sugi.showTextSugi();
			}
			else oldSugi.unshowTextSugi();
		}
	}

	public void showTextGlove()
	{

		RaycastHit detect;

		UnityEngine.Debug.Log("NamaGlove");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{

			INTR_SarungTangan glove = detect.transform.GetComponent<INTR_SarungTangan>();
			if (glove != null)
			{
				oldSarungTangan = glove;
				glove.showNamaGlove();
			}
			else oldSarungTangan.unshowNamaGlove();
		}
	}


	public void showTextKapas()
	{

		RaycastHit detect;

		UnityEngine.Debug.Log("NamaKapas");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{

			INTR_Kapas kapas = detect.transform.GetComponent<INTR_Kapas>();
			if (kapas != null)
			{
				oldKapas = kapas;
				kapas.showNamaKapas();
			}
			else oldKapas.unshowNamaKapas();
		}
	}

	public void showTextAir()
	{

		RaycastHit detect;

		UnityEngine.Debug.Log("TextAir");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{

			INTR_Baldi baldi = detect.transform.GetComponent<INTR_Baldi>();
			if (baldi != null)
			{
				oldAir = baldi;
				baldi.showTextAir();
			}
			else oldAir.unshowTextAir();
		}
	}

	/*public void redToGreen()
	{

		RaycastHit detect;

		UnityEngine.Debug.Log("red");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{

			Arrow redToGreen = detect.transform.GetComponent<Arrow>();
			if (redToGreen != null)
			{
				red = redToGreen;
				redToGreen.unshowRed();
				redToGreen.showGreen();
			}
			
		}
	}
	*/

	public void showbuttonE()
	{

		RaycastHit detect;

		UnityEngine.Debug.Log("buttonE");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{

			INTR_Corpse button = detect.transform.GetComponent<INTR_Corpse>();
			if (button != null)
			{
				Ebutton = button;
				button.showButtonE();
			}
			else {
				Ebutton.unshowButtonE();
			}

		}
	}

	public void interactItem() {

		RaycastHit detect;
		UnityEngine.Debug.Log("detect");
		if (Physics.Raycast(playerCamera.transform.position,playerCamera.transform.forward,out detect, range)) {


			//check tangan full atau tak
			if (not_full) {

				//code to call object script

				//sabun


				//sugi
				INTR_Sugi sugi = detect.transform.GetComponent<INTR_Sugi>();
				if (sugi != null)
				{
					sugi.grab();
					kanan.pegangSugi();
					not_full = false;
				}

				//gayung
				INTR_Gayung gayung = detect.transform.GetComponent<INTR_Gayung>();
				
				if (gayung != null)
				{
					gayung.grab();
					UnityEngine.Debug.Log("dah amik gayung");
					kanan.pegangGayung();
					not_full = false;
				}

				//sabun
				INTR_Sabun sabun = detect.transform.GetComponent<INTR_Sabun>();
				if (sabun != null)
				{
					sabun.grab();
					kanan.pegangSabun();
					not_full = false;
				}

				//glove
				INTR_SarungTangan glove = detect.transform.GetComponent<INTR_SarungTangan>();
				if (glove != null)
				{
					glove.grab();
					not_full = false;
				}

				//kapas
				INTR_Kapas kapas = detect.transform.GetComponent<INTR_Kapas>();
				if (kapas != null)
				{
					kapas.grab();
					not_full = false;
				}


				
				
				//body.enabled = true;

				UnityEngine.Debug.Log(detect.transform.name);



				

			}
		}
	}

	public void release() {

		RaycastHit detect;
		UnityEngine.Debug.Log("Release button clicked ");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range)) {


			if (not_full) { 

				//release gayung
				PadObject padGayung = detect.transform.GetComponent<PadObject>();
				if (padGayung != null)
				{
					padGayung.releaseGayung();
					//kanan.idle();
					not_full = true;
				}

				PadObject padSabun = detect.transform.GetComponent<PadObject>();
				//release gayung
				if (padSabun != null)
				{
					padSabun.releaseSabun();
					//kanan.idle();
					not_full = true;
				}
			}
			

		}

	}

	//curah air
	public void curahAir()
	{
		RaycastHit detectCorpse;
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detectCorpse, range))
		{

			INTR_Corpse corpse = detectCorpse.transform.GetComponent<INTR_Corpse>();
			if (corpse != null)
			{
				UnityEngine.Debug.Log("dah cedok");

				curah.SetBool("ambilAir", false);
				curah.SetBool("curah", true);

				if (Vector3.Angle(Vector3.down, transform.forward) <= 90f)
				{
					myWater.Play();
				}
				else
				{
					myWater.Stop();
				}

			}
			else {
				
				curah.SetBool("curah", false);
			}
		}
	}

	public void cedokAir() {

		RaycastHit detectBaldi;
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detectBaldi, range))
		{

			INTR_Baldi baldi = detectBaldi.transform.GetComponent<INTR_Baldi>();
			if (baldi != null)
			{
				UnityEngine.Debug.Log("dah cedok");
				//baldi.cedokAir();
				//body.enabled = true;
				cedok.cedok();
				kanan.cedok();
				//kanan.pointerCedok();
				ambilAir = true;
				air.showAir();
				//body.enabled = false;
				//kanan.stopTunduk();

				not_full = false;
			}
		}
	}

	

	public void stopTunduk() {

		if (ambilAir == true)
		{
			//air.showAir();
			//ambilAir = false;
			body.enabled = false;
			//kanan.stopTunduk();
		}
		

	}

	


}

