using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
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
	//public AnimationBody cedok;

	//release
	[SerializeField] private Animator idleHand;
	public INTR_Gayung releaseGayung;

	//Full
	public bool not_full = true;

	//ambilAir
	public bool ambilAir = false;
	private Animator body;

	[HideInInspector]
	public bool canMove = true;

	//curah air
	[SerializeField] private Animator curah;
	[SerializeField] private Animator particle1;
	[SerializeField] private Animator cedokAirBersih;
	ParticleSystem myWater;
	public Spill spill;
	private Animator particle;
	public Spill particleAir;
	public bool curahAir = false;

	//moveToPointer
	public Transform pointer;
	public float Targetspeed;
	public bool move = false;

	//sabun
	public bool sabun = false;
	public GameObject viewBuih;
	public Transform sabunPointer;
	public GameObject arrowSabun;

	//angkat mayat
	[SerializeField] private Animator mayat;
	[SerializeField] private Animator angkat;
	public int angkatMayat = 0;


	//canvas
	[SerializeField] private Animator Canvas;
	public int keyVisible = 0;

	public bool particleActive = false;

	void Start()
	{
		characterController = GetComponent<CharacterController>();

		// Lock cursor
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		body = GetComponent<Animator>();

		myWater = GetComponent<ParticleSystem>();

		UnshowArrowProcess();

		airCurahan.SetActive(false);

		infoErrorSabun.SetActive(false);

		viewBuih.SetActive(false);

		arahanArrow.SetActive(false);

		arrowSabun.SetActive(false);
	}


	IEnumerator timetakenCurah()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Started Coroutine at timestamp : " + Time.time);
		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(2);
		curah.SetBool("curah", false);
		airCurahan.SetActive(false);
		basuhanKepala();
		basuhanKakiKiri();
		basuhanKakiKanan();
		basuhanTanganKiri();
		basuhanTanganKanan();
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("Finished Coroutine at timestamp : " + Time.time);
	}

	IEnumerator timetakenAngkatMayat()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Started Coroutine at timestamp : " + Time.time);
		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(23);
		angkat.SetBool("angkat", false);
		mayat.SetBool("mayat", false);
		body.enabled = false;
		arrowSabun.SetActive(true);
		angkat.SetBool("idle", true);
		angkat.SetBool("angkat", false);
		//characterController.enabled = true;
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("Finished Coroutine at timestamp : " + Time.time);
	}

	IEnumerator timetakenSabun()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Started Coroutine at timestamp : " + Time.time);
		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(4);
		curah.SetBool("sabun", false);
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("Finished Coroutine at timestamp : " + Time.time);
	}

	IEnumerator timetakenKey()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Started Coroutine at timestamp : " + Time.time);
		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(1);
		Canvas.SetBool("idle", false);
		Canvas.SetBool("key", false);
		Canvas.SetBool("empty", true);
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("Finished Coroutine at timestamp : " + Time.time);
	}

	IEnumerator unShowInfoErrorSabun()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Started Coroutine at timestamp : " + Time.time);
		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(3);
		infoErrorSabun.SetActive(false);
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("Finished Coroutine at timestamp : " + Time.time);
	}

	IEnumerator unShowArahanArrow()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Started Coroutine at timestamp : " + Time.time);
		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(3);
		arahanArrow.SetActive(false);
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("Finished Coroutine at timestamp : " + Time.time);
	}

	public GameObject airCurahan;
	public Transform pointerAngkatMayat;
	public GameObject buttonE;
	public GameObject arahanArrow;
	public GameObject angkatIndicator;

	void Update()
	{

		showTextSabun();
		showTextGayung();
		showTextSugi();
		showTextGlove();
		showTextKapas();
		showTextAir();


		if (Input.GetButton("Fire1"))
		{
			interactItem();
		}


		if (Input.GetButton("Fire2"))
		{

			if (nakAmbil == true)
			{
				cedokAir();

				nakAmbil = false;
			}
			else
			{
				releaseObject();
			}

		}

		//curah
		if (Input.GetKeyDown(KeyCode.E))
		{


			UnityEngine.Debug.Log("Arrow hilang ");
			curah.SetBool("ambilAir", false);
			curah.SetBool("curah", true);
			curahAir = true;
			airCurahan.SetActive(true);
			if (curahAir == true)
			{
				//5 saat
				StartCoroutine(timetakenCurah());

			}



			//curahAir();
		}

		//sabun
		if (Input.GetKeyDown(KeyCode.F))
		{

			if (Vector3.Distance(transform.position, sabunPointer.position) <= 1)
			{

				curah.SetBool("sabun", true);
				curah.SetBool("Grabbed", false);
				sabun = true;

				viewBuih.SetActive(true);

				if (sabun == true)
				{
					//5 saat
					StartCoroutine(timetakenSabun());

					sabun = false;
				}

			}
			else
			{

				errorSabun();

				StartCoroutine(unShowInfoErrorSabun());
			}




		}



		//TODO: guna count, if count = 1 setBool true else setBool false

		if (Input.GetKeyDown(KeyCode.Q))
		{

			if (angkatIndicator.activeSelf == true)
			{
				if (Vector3.Distance(transform.position, pointerAngkatMayat.position) <= 1)
				{

					angkat.SetBool("angkat", true);
					mayat.SetBool("mayat", true);
					body.enabled = true;

					//moveToPointer();
					move = true;

					if (move == true)
					{
						//5 saat
						StartCoroutine(timetakenAngkatMayat());
						move = false;
					}

				}
				else
				{
					errorSabun();

					StartCoroutine(unShowInfoErrorSabun());

				}
			}
			else
			{
				arahanArrow.SetActive(true);

				StartCoroutine(unShowArahanArrow());
			}
		}



		if (Vector3.Distance(transform.position, pointerAngkatMayat.position) <= 1)
		{

			buttonE.SetActive(true);
		}
		else
		{
			buttonE.SetActive(false);
		}




		if (move.Equals(true))
		{
			moveToPointer();
		}




		// We are grounded, so recalculate move direction based on axes

		Vector3 forward = transform.TransformDirection(Vector3.forward);
		Vector3 right = transform.TransformDirection(Vector3.right);

		// Press Left Shift to run

		bool isRunning = Input.GetKey(KeyCode.LeftShift);
		float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
		float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
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
			rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
			playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
			transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
		}


	}


	public GameObject infoErrorSabun;

	public void errorSabun()
	{

		infoErrorSabun.SetActive(true);

	}



	// if arrow merah semua dah hilang
	// then bila release gayung, muncul arrow kat atas mayat untuk next step(angkat mayat)




	//gerakKePointer
	public void moveToPointer()
	{

		//characterController.enabled = false;

		while (transform.position != pointer.position)
		{
			transform.position = Vector3.MoveTowards(transform.position, pointer.position, Targetspeed * Time.deltaTime);

		}


		UnityEngine.Debug.Log("Move to pointer");

	}

	public void showTextSabun()
	{

		RaycastHit detect;

		UnityEngine.Debug.Log("NamaSabun");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{

			INTR_Sabun sabun = detect.transform.GetComponent<INTR_Sabun>();
			if (sabun != null)
			{
				oldSabun = sabun;
				sabun.showText();
			}
			else oldSabun.unshowText();
		}
	}


	public bool textGayung = false;
	[SerializeField] private Animator infoGayung;
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

				textGayung = true;

				infoGayung.SetBool("viewInfo", true);
				infoGayung.SetBool("closeInfo", false);
			}
			else
			{
				oldGayung.unshowTextGayung();
				textGayung = false;
				infoGayung.SetBool("viewInfo", false);
				infoGayung.SetBool("closeInfo", true);
				infoGayung.SetBool("empty", true);

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

	public bool nakAmbil = false;

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
				nakAmbil = true;
			}
			else oldAir.unshowTextAir();
			//nakAmbil = false;
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



	public void interactItem()
	{

		RaycastHit detect;
		UnityEngine.Debug.Log("detect");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{


			//check tangan full atau tak
			//not_full == true
			if (not_full)
			{

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

	public void release()
	{

		RaycastHit detect;
		UnityEngine.Debug.Log("Release button clicked ");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{


			if (!not_full)
			{

				//release gayung
				PadObject padGayung = detect.transform.GetComponent<PadObject>();
				if (padGayung != null)
				{
					padGayung.releaseGayung();
					idleHand.SetBool("idle", true);
					idleHand.SetBool("Grabbed", false);
					idleHand.SetBool("GrabSabun", false);
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
					idleHand.SetBool("idle", true);
					idleHand.SetBool("Grabbed", false);
					idleHand.SetBool("GrabSabun", false);
				}
			}


		}

	}

	public void releaseObject()
	{

		if (!not_full)
		{
			releaseGayung.release();
			idleHand.SetBool("idle", true);
			idleHand.SetBool("Grabbed", false);
			idleHand.SetBool("GrabSabun", false);
			not_full = true;
		}

	}



	public void cedokAir()
	{

		RaycastHit detectBaldi;
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detectBaldi, range))
		{

			INTR_Baldi baldi = detectBaldi.transform.GetComponent<INTR_Baldi>();
			if (baldi != null)
			{
				UnityEngine.Debug.Log("dah cedok");
				//baldi.cedokAir();
				//body.enabled = true;
				//cedok.cedok();
				kanan.cedok();
				//kanan.pointerCedok();
				ambilAir = true;
				air.showAir();

				//body.enabled = false;
				//kanan.stopTunduk();
				unShowArrowAir();
				showArrowProcess();

				not_full = false;
			}
		}
	}

	public GameObject arrowAir;
	public GameObject arrowProcess;
	public void unShowArrowAir()
	{

		arrowAir.SetActive(false);

	}

	public void showArrowProcess()
	{

		arrowProcess.SetActive(true);

	}
	public void UnshowArrowProcess()
	{

		arrowProcess.SetActive(false);

	}

	public void stopTunduk()
	{

		if (ambilAir == true)
		{
			//air.showAir();
			//ambilAir = false;
			body.enabled = false;
			//kanan.stopTunduk();
		}


	}

	public CollisionTanganKiri arrowDetectTanagnKiri;
	public CollisionTanganKanan arrowDetectTanganKanan;
	public CollKakiKanan arrowDetectKakiKanan;
	public CollKakiKiri arrowDetectKakiKiri;
	public CollKepala arrowDetectKepala;

	public void basuhanTanganKiri()
	{
		arrowDetectTanagnKiri.arrowDetect();
	}

	public void basuhanTanganKanan()
	{
		arrowDetectTanganKanan.arrowDetect();
	}

	public void basuhanKakiKiri()
	{
		arrowDetectKakiKiri.arrowDetect();
	}

	public void basuhanKakiKanan()
	{
		arrowDetectKakiKanan.arrowDetect();
	}

	public void basuhanKepala()
	{
		arrowDetectKepala.arrowDetect();
	}


}

