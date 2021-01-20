using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

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

	public gayungBaru oldGayungBilasSabun = null;

	public INTR_Sugi oldSugi = null;
	public INTR_SarungTangan oldSarungTangan = null;
	public INTR_Kapas oldKapas = null;
	public INTR_Baldi oldAir = null;
	public INTR_Gayung air = null;

	public INTR_Tuala tuala;

	public GameObject airBilasSabun;

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
	public INTR_Sabun releaseSabun;
	public gayungBaru releaseGayung2;

	//Full
	public bool not_full = true;

	//ambilAir
	public bool ambilAir = false;
	private Animator body;
	

	[HideInInspector]
	public bool canMove = true;


	//curah air
	[SerializeField] private Animator curah;
	[SerializeField] private Animator kiri;
	[SerializeField] private Animator cameraAngkatMayat;
	[SerializeField] private Animator particle1;
	[SerializeField] private Animator cedokAirBersih;
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

	public GameObject arrowProcessSabun;


	public GameObject airCurahan;
	public Transform pointerAngkatMayat;
	public GameObject buttonE;
	public GameObject arahanArrow;
	public GameObject angkatIndicator;

	public GameObject sabunIndicator;
	public GameObject arrowGayungBilasSabun;

	public GameObject arrowBasuhan;
	public GameObject arrowBilasSabun;
	public GameObject detecterSabun;
	public GameObject detecterWudhu;

	public Text text;

	void Start()
	{
		

		characterController = GetComponent<CharacterController>();

		// Lock cursor
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		body = GetComponent<Animator>();

		UnshowArrowProcess();

		airCurahan.SetActive(false);
		infoErrorSabun.SetActive(false);
		viewBuih.SetActive(false);
		arahanArrow.SetActive(false);
		arrowSabun.SetActive(false);
		buihKakiKiriStay.SetActive(false);
		buihKakiKiriAnimate.SetActive(false);
		buihTanganKiriStay.SetActive(false);
		buihTanganKiriAnimate.SetActive(false);
		buihKakiKananStay.SetActive(false);
		buihKakiKananAnimate.SetActive(false);
		buihTanganKananStay.SetActive(false);
		buihTanganKananAnimate.SetActive(false);
		buihKepalaStay.SetActive(false);
		buihKepalaAnimate.SetActive(false);
		arrowBilasAirSabun.SetActive(false);
		bodyBersih.SetActive(true);
		pegangGayungIndicator.SetActive(false);
		indicatorWudhu.SetActive(false);
		//arrowWudhu.SetActive(false);
		ambilBarangButton.SetActive(false);
		cedokButton.SetActive(false);
		curahButton.SetActive(false);
		clickC.SetActive(false);
		airBilasSabun.SetActive(false);
		gayungBilasSabun.SetActive(false);
		wudhuDetecter.SetActive(false);
		arrowGayungBilasSabun.SetActive(false);
		arrowBasuhan.SetActive(false);
		arrowBilasSabun.SetActive(false);
		leftClick.SetActive(false);
		rightClick.SetActive(false);
		e.SetActive(false);
		f.SetActive(false);
		c.SetActive(false);
		curahDetecter.SetActive(false);
		arrowCedokAirWudhu.SetActive(false);
		PointerSabun.SetActive(false);
		notiLetakSabun.SetActive(false);
		notiWudhu.SetActive(false);
		buttonR.SetActive(false);
		arrowLapJenazah.SetActive(false);
		triggerLap.SetActive(false);
		arrowTualaDisplay.SetActive(false);
		gloveBuang.SetActive(false);
		gloveBuang2.SetActive(false);
		arrowBuangGlove.SetActive(false);

		// Lock cursor
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		back.SetActive(false);
		mainMenu.SetActive(false);
		pauseBG.SetActive(false);
		pg2.SetActive(false);
		pg3.SetActive(false);

		arrowGlove2.SetActive(false);
	}

	public GameObject bodyBersih;
	public GameObject airCurahan2;
	public GameObject arrowLapKepala;
	public GameObject arrowLapTanganKiri;
	public GameObject arrowLapTanganKanan;
	public GameObject arrowLapKakiKiri;
	public GameObject arrowLapKakiKanan;
	public GameObject menuUlangSemula;
	IEnumerator timetakenCurah()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Started Coroutine at timestamp : " + Time.time);
		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(2);
		curah.SetBool("curah", false);
		basuhanKepala();
		basuhanKakiKiri();
		basuhanKakiKanan();
		basuhanTanganKiri();
		basuhanTanganKanan();
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("Finished Coroutine at timestamp : " + Time.time);
	}

	IEnumerator timetakenAirBilasSabun()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Started Coroutine at timestamp : " + Time.time);
		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(2);
		airBilas.SetActive(false);
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("Finished Coroutine at timestamp : " + Time.time);
	}

	// - Bilas timer - 
	IEnumerator timetakenBilasSabun()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Mula Bilas Sabun");
		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(2);
		curah.SetBool("curah", false);
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("End Bilas Sabun");
	}


	IEnumerator timetakenWudhu()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Start wudhu");
		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(2);
		curah.SetBool("curah", false);
		kiri.SetBool("wudhu", false);
		kiri.SetBool("idle", true);
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("Done wudhu");
	}
	 
	IEnumerator timetakenAngkatMayat()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Mula angkat mayat ");
		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(18);
		//angkat.SetBool("angkat", false);
		mayat.SetBool("mayat", false);
		curah.SetBool("idle", true);
		curah.SetBool("angkatMayatNew", false);
		kiri.SetBool("tekanPerut", false);
		kiri.SetBool("idle", true);
		//body.enabled = false;
		//playIndicator.SetActive(false);
		arrowBuangGlove.SetActive(true);
		
		ArrowAngkat.SetActive(false);
		circleAngkat.SetActive(false);
		Pointer.SetActive(false);
		//angkat.SetBool("idle", true);
		//angkat.SetBool("angkat", false);
		bodyBersih.SetActive(false);

		notiBuangGlove.SetActive(true);

		//characterController.enabled = true;
		//After we have waited 5 seconds print the time again.
		characterController.enabled = true;
		UnityEngine.Debug.Log("Selesai ");
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

	IEnumerator timetakenAirCurahan()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("start keluar air");
		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(4);
		airCurahan.SetActive(false);
		airCurahan2.SetActive(true);
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("stop keluar air");
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

	IEnumerator buihAnimate()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Started Coroutine at timestamp : " + Time.time);
		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(4);
		buihKakiKiriAnimate.SetActive(false);
		buihKakiKananAnimate.SetActive(false);
		buihTanganKiriAnimate.SetActive(false);
		buihTanganKananAnimate.SetActive(false);
		buihKepalaAnimate.SetActive(false);
		viewBuih.SetActive(false);
		
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("Finished Coroutine at timestamp : " + Time.time);
	}

	IEnumerator unnotiGayung()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Start noti gayung");
		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(3);
		notiGayung.SetActive(false);
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("Start noti gayung");
	}

	

	IEnumerator backToGrabTuala()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Start grab semula");
		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(2);
		curah.SetBool("grabtuala", true);
		curah.SetBool("lapjenazah", false);
		kiri.SetBool("lap", false);
		kiri.SetBool("idle", true);
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("done grab");
	}

	IEnumerator arrowLapKepalaHijau()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Arrow Kepala Hijau in 3 seconds");
		//yield on a new YieldInstruction that waits for 3 seconds.
		yield return new WaitForSeconds(3);
		arrowLapKepala.SetActive(false);
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("Done Lap");
	}

	IEnumerator arrowLapTanganKiriHijau()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Arrow Tangan Kiri hijau in 3 seconds");
		//yield on a new YieldInstruction that waits for 3 seconds.
		yield return new WaitForSeconds(3);
		arrowLapTanganKiri.SetActive(false);
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("Done Lap");
	}

	IEnumerator arrowLapTanganKananHijau()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Arrow Tangan Kanan Hijau in 3 seconds");
		//yield on a new YieldInstruction that waits for 3 seconds.
		yield return new WaitForSeconds(3);
		arrowLapTanganKanan.SetActive(false);
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("Done Lap");
	}

	IEnumerator arrowLapKakiKiriHijau()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Arrow Kaki Kiri Hijau in 3 seconds");
		//yield on a new YieldInstruction that waits for 3 seconds.
		yield return new WaitForSeconds(3);
		arrowLapKakiKiri.SetActive(false);
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("Done Lap");
	}

	IEnumerator arrowLapKakiKananHijau()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Arrow Kaki Kanan Hijau in 3 seconds");
		//yield on a new YieldInstruction that waits for 3 seconds.
		yield return new WaitForSeconds(3);
		arrowLapKakiKanan.SetActive(false);
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("Done Lap");
	}

	IEnumerator endTutorialMenu()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("End Tutorial in 10s");
		//yield on a new YieldInstruction that waits for 3 seconds.
		yield return new WaitForSeconds(10);
		Time.timeScale = 0;
		gamePaused = true;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		back.SetActive(true);
		mainMenu.SetActive(true);
		menuUlangSemula.SetActive(true);
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("End Menu appear");
	}

	public Transform detecter1;
	public Transform detecter2;
	public Transform detecter4;
	public Transform detecter6;
	public Transform detecter7;
	public Transform detecter8;
	public Transform detecter10;
	public Transform detecter12;
	public Transform detecter13;
	public GameObject buihKakiKiriStay;
	public GameObject buihKakiKiriAnimate;
	public GameObject buihKakiKananStay;
	public GameObject buihKakiKananAnimate;
	public GameObject buihTanganKiriStay;
	public GameObject buihTanganKiriAnimate;
	public GameObject buihTanganKananStay;
	public GameObject buihTanganKananAnimate;
	public GameObject buihKepalaStay;
	public GameObject buihKepalaAnimate;
	public GameObject detect;
	public GameObject arrowMerahKakiKiri;
	public GameObject arrowMerahKakiKanan;
	public GameObject arrowMerahTanganKiri;
	public GameObject arrowMerahTanganKanan;
	public GameObject arrowMerahKepala;
	public GameObject arrowBilasAirSabun;
	public GameObject gayungIndicator;
	public Transform detecterSiramKakiKiri;
	public Transform detecterSiramKakiKanan;
	public Transform detecterSiramTanganKiri;
	public Transform detecterSiramTanganKanan;
	public Transform detecterSiramKepala;
	public GameObject indicatorWudhu;
	public Transform triggerLenganKiri;
	public Transform triggerLenganKanan;
	public Transform triggerKakiKiri;
	public Transform triggerKakiKanan;
	public Transform triggerKepala;
	public GameObject arrowWudhu;
	public GameObject arrowWudhuLenganKiri;
	public GameObject arrowWudhuLenganKanan;
	public GameObject arrowWudhuKakiKiri;
	public GameObject arrowWudhuKakiKanan;
	public GameObject arrowWudhuKepala;
	public GameObject ArrowAngkat;
	public GameObject circleAngkat;
	public GameObject Pointer;
	public GameObject pegangGayungIndicator;
	public GameObject arrowSiram;
	public Transform detecterSiramKakiKiri1;
	public Transform detecterSiramKakiKiri2;
	public Transform detecterSiramKakiKiri3;
	public GameObject ambilBarangButton;
	public GameObject cedokButton;
	public GameObject curahButton;
	public GameObject namaGayung;
	public GameObject namaGlove;
	public GameObject namaSabun;
	public GameObject notiGayung;
	public GameObject arrowSiramMerahTanganKiri;
	public GameObject arrowSiramMerahTanganKanan;
	public GameObject arrowSiramMerahKakiKiri;
	public GameObject arrowSiramMerahKakiKanan;
	public GameObject arrowSiramMerahKepala;
	public GameObject indicatorInfoGayungGlove;
	public GameObject indicatorInfoGayungGlove2;
	public GameObject arrowGlove;
	public GameObject notiBefore;
	public GameObject wudhuDetecter;
	public Transform triggerwudhuTanganKanan;
	public Transform triggerwudhuTanganKiri;
	public Transform triggerwudhuKakiKanan;
	public Transform triggerwudhuKakiKiri;
	public Transform triggerwudhuKepala;
	public GameObject clickC;
	public GameObject tanganKanan;
	public GameObject playIndicator;
	public GameObject namaGayung2;
	public GameObject gayungBilasSabun;
	public GameObject arrowSabunMerahKakiKiri;
	public GameObject arrowSabunMerahKakiKanan;
	public GameObject arrowSabunMerahTanganKiri;
	public GameObject arrowSabunMerahTanganKanan;
	public GameObject arrowSabunMerahKepala;
	public GameObject leftClick;
	public GameObject rightClick;
	public GameObject e;
	public GameObject f;
	public GameObject c;
	public GameObject gayung1;
	public GameObject gayung2;
	public GameObject namaBaldi;
	public GameObject curahDetecter;
	public GameObject arrowWudhukanJenazah;
	public GameObject arrowCedokAirWudhu;
	public GameObject PointerSabun;
	public GameObject airBilas;
	public GameObject arrowAmbilairBilasSabun;
	public int count = 0;
	public GameObject gayung3;
	public GameObject airGayung2;
	public GameObject notiWudhu;
	public GameObject arrowTualaDisplay;

	/// <summary>
	/// notification:
	/// - lepas basuhan pertama(arahan untuk letak gayung dan pakai glove)
	/// - sebelum angkat mayat(bagitahu cara2 angkat mayat, handle mayat dengan lembut dan sopan)
	/// - selepas letak mayat 
	/// belum siap:
	/// - effect kotoran lepas tekan perut (guna startTimeCount)
	/// - arrow untuk amik air
	/// - cedok air
	/// - siram mayat(animate siram active bila dekat dengan mayat & show air,unshow kotoran)
	/// - guna arrow merah(duplicate), if sabunStay true, then arrow hijau
	/// - bilas sabun
	/// - arrow untuk amir air
	/// - cedok air
	/// - siram mayat(animate siram active bila dekat dengan mayat & show air,unshow sabunStay)
	/// error/problem:
	/// </summary>

	public GameObject namaAir;
	public GameObject notiLetakSabun;
	public GameObject detecterSabunMayat;
	public GameObject detecterCurah;
	public GameObject detecterSiram;
	public GameObject tualaDisplay;
	public Transform triggerLapKepala;
	public Transform triggerLapTanganKiri;
	public Transform triggerLapTanganKanan;
	public Transform triggerLapKakiKiri;
	public Transform triggerLapKakiKanan;
	public GameObject buttonR;
	public GameObject namaTuala;
	public GameObject namaTongSampah;
	public GameObject arrowLapJenazah;
	public GameObject triggerLap;
	public ThrowGlove buangGlove;
	public ThrowGlove buangGlove2;
	public GameObject gloveDisplay;
	public GameObject gloveBuang;
	
	public GameObject arrowAmbilTuala;
	public gayungBaru gayungBaru;
	public GameObject arrowBuangGlove;
	public bool gamePaused = false;
	public GameObject back;
	public GameObject mainMenu;
	public GameObject pauseBG;
	public int countPage = 0;

	public GameObject Q1;
	public GameObject hoverTrue;
	public GameObject hoverFalse;
	public trueButton betulQ1;

	public trueButton buttonTrueQ1;
	public trueButton buttonFalseQ1;

	public GameObject notiAngkatJenazah;
	public GameObject notiBuangGlove;
	public GameObject namaGlove2;

	//public ChangeToGlove leftHand;
	//public ChangeToGlove rightHand;

	public GameObject gloveBuang2;
	public GameObject gloveDisplay2;

	public GameObject arrowGlove2;
	void Update()
	{
		if (arrowLapKepala.activeSelf == false && arrowLapKakiKanan.activeSelf == false && arrowLapKakiKiri.activeSelf == false && arrowLapTanganKanan.activeSelf == false && arrowLapTanganKiri.activeSelf == false) {
			StartCoroutine(endTutorialMenu());
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (gamePaused == false)
			{
				Time.timeScale = 0;
				gamePaused = true;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				back.SetActive(true);
				mainMenu.SetActive(true);
			}
			else
			{
				mainMenu.SetActive(false);
				back.SetActive(false);
			}
		}

		if (back.activeSelf == true)
		{
			gamePaused = false;
			pauseBG.SetActive(true);
		}
		else
		{
			Time.timeScale = 1;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		if (arrowSiramMerahTanganKiri.activeSelf == false && arrowSiramMerahTanganKanan.activeSelf == false && arrowSiramMerahKakiKiri.activeSelf == false && arrowSiramMerahKakiKanan.activeSelf == false && arrowSiramMerahKepala.activeSelf == false && indicatorInfoGayungGlove.activeSelf == true && indicatorInfoGayungGlove2.activeSelf == true)
		{
			notiGayung.SetActive(true);
		}
		else
		{
			notiGayung.SetActive(false);
		}

		showTextSabun();
		showTextGayung();
		showTextGayungBilasSabun();
		showTextSugi();
		showTextGlove();
		showTextGlove2();
		showTextKapas();
		showTextAir();
		showTextTongSampah();
		showTextTuala();
		showButtonCurah();
		nextButton1();
		Q1trueHover();

		if (namaAir.activeSelf == true || namaTongSampah.activeSelf == true)
		{
			rightClick.SetActive(true);
		}
		else {
			rightClick.SetActive(false);
		}

		if (namaGayung.activeSelf == true || namaGlove.activeSelf == true || namaSabun.activeSelf == true || namaGayung2.activeSelf == true || namaTuala.activeSelf == true)
		{
			leftClick.SetActive(true);
		}
		else {
			leftClick.SetActive(false);
		}

		if (airBilasSabun.activeSelf == true) {
			notiLetakSabun.SetActive(false);
		}
		////////////////////////////////////////////////////////////////////////////////////////////////////////// Grab Release -start- /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		if (Input.GetButtonDown("Fire1") )
		{

			if (Q1.activeSelf == true) {

				if (hoverTrue.activeSelf == true)
				{
					betulQ1.toGreen();
				}

				if (hoverFalse.activeSelf == true)
				{
					betulQ1.toRed();
				}

			}

			
			
			
			if (greenButton.activeSelf == true) {
				if (countPage == 0)
				{
					pg2.SetActive(true);
					countPage = countPage + 1;
				}
				else if (countPage == 1)
				{
					pg3.SetActive(true);
					countPage = countPage + 1;
				}
				else 
				{
					pg2.SetActive(false);
					pg3.SetActive(false);
					countPage = 0;
				}

			}
			else if ((namaGayung.activeSelf == true || namaGlove.activeSelf == true || namaGlove2.activeSelf == true || namaSabun.activeSelf == true || namaGayung2.activeSelf == true) && namaTuala.activeSelf == false) {
				interactItem();
			}
			else if (namaTuala.activeSelf == true) {

				if (arrowAmbilTuala.activeSelf == true) {

					curah.SetBool("grabtuala", true);
					curah.SetBool("idle", false);
					interactTuala();
				}
			}
			//Basuhan pertama (curah air) 
			else if (gayungIndicator.activeSelf == true)
			{
				if ((Vector3.Distance(transform.position, detecterSiramTanganKanan.position) <= 2) || (Vector3.Distance(transform.position, detecterSiramTanganKiri.position) <= 2) || (Vector3.Distance(transform.position, detecterSiramKakiKanan.position) <= 2) || (Vector3.Distance(transform.position, detecterSiramKakiKiri.position) <= 2))
				{
					UnityEngine.Debug.Log("Arrow hilang ");
					curah.SetBool("ambilAir", false);
					curah.SetBool("curah", true);
					curahAir = true;
					if (curahAir == true)
					{
						//5 saat
						StartCoroutine(timetakenCurah());
					}
				}
				else
				{
					errorSabun();
					StartCoroutine(unShowInfoErrorSabun());
				}

			}
			else if (indicatorWudhu.activeSelf == true)
			{

				arrowWudhu.SetActive(true);

				//check distance
				if ((Vector3.Distance(transform.position, triggerLenganKiri.position) <= 2))
				{

					UnityEngine.Debug.Log("Arrow hilang ");
					curah.SetBool("ambilAir", false);
					curah.SetBool("curah", true);
					curahAir = true;
					arrowWudhuLenganKiri.SetActive(false);
					if (curahAir == true)
					{
						//5 saat
						StartCoroutine(timetakenWudhu());
					}

				}
				else if ((Vector3.Distance(transform.position, triggerLenganKanan.position) <= 2))
				{
					UnityEngine.Debug.Log("Arrow hilang ");
					curah.SetBool("ambilAir", false);
					curah.SetBool("curah", true);
					curahAir = true;
					arrowWudhuLenganKanan.SetActive(false);
					if (curahAir == true)
					{
						//5 saat
						StartCoroutine(timetakenWudhu());

					}
				}
				else if ((Vector3.Distance(transform.position, triggerKakiKiri.position) <= 2))
				{
					UnityEngine.Debug.Log("Arrow hilang ");
					curah.SetBool("ambilAir", false);
					curah.SetBool("curah", true);
					curahAir = true;
					arrowWudhuKakiKiri.SetActive(false);
					if (curahAir == true)
					{
						//5 saat
						StartCoroutine(timetakenWudhu());

					}

				}
				else if ((Vector3.Distance(transform.position, triggerKakiKanan.position) <= 2))
				{
					UnityEngine.Debug.Log("Arrow hilang ");
					curah.SetBool("ambilAir", false);
					curah.SetBool("curah", true);
					curahAir = true;
					arrowWudhuKakiKanan.SetActive(false);
					if (curahAir == true)
					{
						//5 saat
						StartCoroutine(timetakenWudhu());

					}
				}
				else if ((Vector3.Distance(transform.position, triggerKepala.position) <= 2))
				{
					UnityEngine.Debug.Log("Arrow hilang ");
					curah.SetBool("ambilAir", false);
					curah.SetBool("curah", true);
					curahAir = true;
					arrowWudhuKepala.SetActive(false);
					if (curahAir == true)
					{
						//5 saat
						StartCoroutine(timetakenWudhu());
					}
				}
				else
				{
					infoErrorSabun.SetActive(true);
					StartCoroutine(unShowInfoErrorSabun());
				}

			}
			else if (sabunIndicator.activeSelf == false)
			{
				//public GameObject buihKakiStay;
				//public GameObject buihKakiAnimate;
				if (((Vector3.Distance(transform.position, detecter7.position) <= 2) || (Vector3.Distance(transform.position, detecter13.position) <= 2) || (Vector3.Distance(transform.position, detecter8.position) <= 2) || (Vector3.Distance(transform.position, detecter10.position) <= 2) || (Vector3.Distance(transform.position, detecter12.position) <= 2) || Vector3.Distance(transform.position, detecter1.position) <= 2) || (Vector3.Distance(transform.position, detecter2.position) <= 2) || (Vector3.Distance(transform.position, detecter4.position) <= 2) || (Vector3.Distance(transform.position, detecter6.position) <= 2))
				{
					//detect.SetActive(true);
					curah.SetBool("sabun", true);
					curah.SetBool("Grabbed", false);
					sabun = true;
					viewBuih.SetActive(true);

					//kaki kiri
					if ((Vector3.Distance(transform.position, detecter6.position) <= 2))
					{
						buihKakiKiriStay.SetActive(true);
						buihKakiKiriAnimate.SetActive(true);
						StartCoroutine(buihAnimate());
						arrowMerahKakiKiri.SetActive(false);
					}

					//kaki kanan
					if ((Vector3.Distance(transform.position, detecter12.position) <= 2))
					{
						buihKakiKananStay.SetActive(true);
						buihKakiKananAnimate.SetActive(true);
						StartCoroutine(buihAnimate());
						arrowMerahKakiKanan.SetActive(false);
					}

					//tanganKiri
					if ((Vector3.Distance(transform.position, detecter2.position) <= 2) || (Vector3.Distance(transform.position, detecter4.position) <= 2))
					{
						buihTanganKiriStay.SetActive(true);
						buihTanganKiriAnimate.SetActive(true);
						StartCoroutine(buihAnimate());
						arrowMerahTanganKiri.SetActive(false);
					}

					//tanganKanan
					if ((Vector3.Distance(transform.position, detecter8.position) <= 2) || (Vector3.Distance(transform.position, detecter10.position) <= 2))
					{
						buihTanganKananStay.SetActive(true);
						buihTanganKananAnimate.SetActive(true);
						StartCoroutine(buihAnimate());
						arrowMerahTanganKanan.SetActive(false);
					}

					//kepala
					if ((Vector3.Distance(transform.position, detecter13.position) <= 2))
					{
						buihKepalaStay.SetActive(true);
						buihKepalaAnimate.SetActive(true);
						StartCoroutine(buihAnimate());
						arrowMerahKepala.SetActive(false);
					}

					if (sabun == true)
					{
						//5 saat
						StartCoroutine(timetakenSabun());
						sabun = false;
					}
				}
				else
				{
					viewBuih.SetActive(false);
					detect.SetActive(false);
				}

			}
			else
			{
				errorSabun();
				StartCoroutine(unShowInfoErrorSabun());
			}
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////////// Arrow Sabun -start- /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//if arrow merah sabun hilang, show arrow letak sabun
		//lepas letak sabun, show arrowBilasSabun
		if (arrowMerahKakiKanan.activeSelf == false && arrowMerahKakiKiri.activeSelf == false && arrowMerahTanganKanan.activeSelf == false && arrowMerahTanganKiri.activeSelf == false && arrowMerahKepala.activeSelf == false && indicatorInfoGayungGlove.activeSelf == true && arrowGlove.activeSelf == false)
		{
			indicatorInfoGayungGlove.SetActive(true);
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////////// Curah button -start- /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		//display button E
		if (curahDetecter.activeSelf == true) {

			if ((Vector3.Distance(transform.position, detecter6.position) <= 2) || (Vector3.Distance(transform.position, detecter12.position) <= 2) || (Vector3.Distance(transform.position, detecter2.position) <= 2) || (Vector3.Distance(transform.position, detecter4.position) <= 2) || (Vector3.Distance(transform.position, detecter8.position) <= 2) || (Vector3.Distance(transform.position, detecter10.position) <= 2) || (Vector3.Distance(transform.position, detecter13.position) <= 2))
			{
				e.SetActive(true);
			}
			else
			{
				e.SetActive(false);
			}
		}

		//Process

		

		if (Input.GetButton("Fire2"))
		{
			if (gloveDisplay.activeSelf == false && gloveBuang.activeSelf == false && namaTongSampah.activeSelf == true)
			{
					
				arrowBuangGlove.SetActive(false);
				gloveBuang.SetActive(true);
				buangGlove.release();
				not_full = true;
				notiBuangGlove.SetActive(false);
				arrowGlove2.SetActive(true);

			}

			if (gloveDisplay2.activeSelf == false && gloveBuang2.activeSelf == false && namaTongSampah.activeSelf == true) {
				
				gloveBuang2.SetActive(true);
				buangGlove2.release();
			}

			if (nakAmbil == true)
			{
				if (gayung1.activeSelf == true && arrowCedokAirWudhu.activeSelf == false)
				{
					cedokAir();
					arrowBasuhan.SetActive(true);
					nakAmbil = false;

				}
				else if (gayung2.activeSelf == true && arrowCedokAirWudhu.activeSelf == false)
				{
					cedokAirBilasSabun();
					nakAmbil = false;
					notiLetakSabun.SetActive(false);

				}
				else if (gayung2.activeSelf == true && arrowCedokAirWudhu.activeSelf == true)
				{
					cedokAirWudhu();
					arrowWudhukanJenazah.SetActive(true);
					nakAmbil = false;
					notiWudhu.SetActive(false);
				}
				else
				{
					//sila ambil gayung noti
				}
			}
			else if (gayungBilasSabun.activeSelf == true)
			{

				if ((buihKakiKiriStay.activeSelf == false && buihKakiKananStay.activeSelf == false && buihTanganKiriStay.activeSelf == false && buihTanganKananStay.activeSelf == false && buihKepalaStay.activeSelf == false) && (arrowWudhuKakiKanan.activeSelf == false && arrowWudhuKakiKiri.activeSelf == false && arrowWudhuKepala.activeSelf == false && arrowWudhuLenganKanan.activeSelf == false && arrowWudhuLenganKiri.activeSelf == false))
				{
					gayungBaru.release();
					curah.SetBool("Grabbed", false);
					curah.SetBool("idle", true);
				}
				else
				{ 
					//noti ikut anak panah
				}
			}
			else
			{
					releaseObject();
					nakAmbil = false;
			}

			


			
		}

		// - active arrow amik gayung 2 - 
		////////////////////////////////////////////////////////////////////////////////////////////////////////// Curah -start- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		//set active E button to false when f button activeSelf == true
		if (f.activeSelf == true) {
			e.SetActive(false);
		}

		//set active E button to false when f button activeSelf == true
		if (c.activeSelf == true)
		{
			e.SetActive(false);
			f.SetActive(false);
			buttonE.SetActive(false);
		}

		if (buttonE.activeSelf == true)
		{
			e.SetActive(false);
			f.SetActive(false);
		}

		if (arrowWudhukanJenazah.activeSelf == true) {

			detecterSabunMayat.SetActive(false);
			detecterCurah.SetActive(false);
			detecterSiram.SetActive(false);
		}

		if (buttonR.activeSelf == true) {

			f.SetActive(false);
			e.SetActive(false);
			buttonE.SetActive(false);
			c.SetActive(false);
		}

		// keyDown E funtion
		if (Input.GetKeyDown(KeyCode.E))
		{
			

			//-------------------------------------------------------------------------------------------------bilas sabun
			if (gayung2.activeSelf == true && wudhuDetecter.activeSelf == false)
			{
				airCurahan2.SetActive(true);

				StartCoroutine(timetakenAirCurahan());

				//kaki kiri
				if ((Vector3.Distance(transform.position, detecter6.position) <= 2))
				{
					buihKakiKiriStay.SetActive(false);
					curah.SetBool("ambilAir", false);
					curah.SetBool("curah", true);
					curahAir = true;
					
					StartCoroutine(timetakenBilasSabun());

					if (buihKakiKiriStay.activeSelf == false  && buihKakiKananStay.activeSelf == false && buihTanganKiriStay.activeSelf == false && buihTanganKananStay.activeSelf == false && buihKepalaStay.activeSelf == false)
					{
						//airBilas.SetActive(false);
						StartCoroutine(timetakenAirBilasSabun());
						arrowCedokAirWudhu.SetActive(true);
						notiWudhu.SetActive(true);
					}	
				}

				//kaki kanan
				if ((Vector3.Distance(transform.position, detecter12.position) <= 2))
				{
					buihKakiKananStay.SetActive(false);
					curah.SetBool("ambilAir", false);
					curah.SetBool("curah", true);
					curahAir = true;
					StartCoroutine(timetakenBilasSabun());

					if (buihKakiKiriStay.activeSelf == false && buihKakiKananStay.activeSelf == false && buihTanganKiriStay.activeSelf == false && buihTanganKananStay.activeSelf == false && buihKepalaStay.activeSelf == false)
					{
						StartCoroutine(timetakenAirBilasSabun());
						arrowCedokAirWudhu.SetActive(true);
						notiWudhu.SetActive(true);
					}

				}

				//Tangan kiri
				if ((Vector3.Distance(transform.position, detecter2.position) <= 2) || (Vector3.Distance(transform.position, detecter4.position) <= 2))
				{
					buihTanganKiriStay.SetActive(false);
					curah.SetBool("ambilAir", false);
					curah.SetBool("curah", true);
					curahAir = true;
					StartCoroutine(timetakenBilasSabun());

					if (buihKakiKiriStay.activeSelf == false && buihKakiKananStay.activeSelf == false && buihTanganKiriStay.activeSelf == false && buihTanganKananStay.activeSelf == false && buihKepalaStay.activeSelf == false)
					{
						StartCoroutine(timetakenAirBilasSabun());
						arrowCedokAirWudhu.SetActive(true);
						notiWudhu.SetActive(true);
					}
				}

				//Tangan Kanan
				if ((Vector3.Distance(transform.position, detecter8.position) <= 2)|| (Vector3.Distance(transform.position, detecter10.position) <= 2))
				{
					buihTanganKananStay.SetActive(false);
					curah.SetBool("ambilAir", false);
					curah.SetBool("curah", true);
					curahAir = true;
					StartCoroutine(timetakenBilasSabun());

					if (buihKakiKiriStay.activeSelf == false && buihKakiKananStay.activeSelf == false && buihTanganKiriStay.activeSelf == false && buihTanganKananStay.activeSelf == false && buihKepalaStay.activeSelf == false)
					{
						StartCoroutine(timetakenAirBilasSabun());
						arrowCedokAirWudhu.SetActive(true);
						notiWudhu.SetActive(true);
					}

				}

				//kepala
				if ((Vector3.Distance(transform.position, detecter13.position) <= 2))
				{
					buihKepalaStay.SetActive(false);
					curah.SetBool("ambilAir", false);
					curah.SetBool("curah", true);
					curahAir = true;
					StartCoroutine(timetakenBilasSabun());

					if (buihKakiKiriStay.activeSelf == false && buihKakiKananStay.activeSelf == false && buihTanganKiriStay.activeSelf == false && buihTanganKananStay.activeSelf == false && buihKepalaStay.activeSelf == false)
					{
						StartCoroutine(timetakenAirBilasSabun());
						arrowCedokAirWudhu.SetActive(true);
						notiWudhu.SetActive(true);
					}

				}
							
			}

			//-------------------------------------------------------------------------------------------------siram basuhan pertama
			if (gayung1.activeSelf == true) {

				airCurahan.SetActive(true);

				StartCoroutine(timetakenAirCurahan());

				UnityEngine.Debug.Log("Arrow hilang ");
					curah.SetBool("ambilAir", false);
					curah.SetBool("curah", true);
					curahAir = true;
					StartCoroutine(timetakenCurah());

			}

			//-------------------------------------------------------------------------------------------------siram wudhu
			if (gayung2.activeSelf == true && wudhuDetecter.activeSelf == true)
			{
				airCurahan2.SetActive(true);

				StartCoroutine(timetakenAirCurahan());

				if (clickC.activeSelf == true && arrowWudhu.activeSelf == true)
				{
					if ((Vector3.Distance(transform.position, triggerwudhuTanganKanan.position) <= 2))
					{
						arrowWudhuLenganKanan.SetActive(false);
						UnityEngine.Debug.Log("Arrow hilang ");
						curah.SetBool("ambilAir", false);
						curah.SetBool("curah", true);
						curahAir = true;
						kiri.SetBool("wudhu", true);
						kiri.SetBool("idle", false);
						StartCoroutine(timetakenWudhu());

                        if (arrowWudhuKakiKanan.activeSelf == false && arrowWudhuKakiKiri.activeSelf == false && arrowWudhuKepala.activeSelf == false && arrowWudhuLenganKanan.activeSelf == false && arrowWudhuLenganKiri.activeSelf == false)
						{
							airGayung2.SetActive(false);
						}

					}
					else if ((Vector3.Distance(transform.position, triggerwudhuTanganKiri.position) <= 2))
					{
						arrowWudhuLenganKiri.SetActive(false);
						UnityEngine.Debug.Log("Arrow hilang ");
						curah.SetBool("ambilAir", false);
						curah.SetBool("curah", true);
						curahAir = true;
						kiri.SetBool("wudhu", true);
						kiri.SetBool("idle", false);
						StartCoroutine(timetakenWudhu());

						if (arrowWudhuKakiKanan.activeSelf == false && arrowWudhuKakiKiri.activeSelf == false && arrowWudhuKepala.activeSelf == false && arrowWudhuLenganKanan.activeSelf == false && arrowWudhuLenganKiri.activeSelf == false)
						{
							airGayung2.SetActive(false);
						}
					}
					else if ((Vector3.Distance(transform.position, triggerwudhuKakiKanan.position) <= 2))
					{
						arrowWudhuKakiKanan.SetActive(false);
						UnityEngine.Debug.Log("Arrow hilang ");
						curah.SetBool("ambilAir", false);
						curah.SetBool("curah", true);
						curahAir = true;
						kiri.SetBool("wudhu", true);
						kiri.SetBool("idle", false);
						StartCoroutine(timetakenWudhu());

						if (arrowWudhuKakiKanan.activeSelf == false && arrowWudhuKakiKiri.activeSelf == false && arrowWudhuKepala.activeSelf == false && arrowWudhuLenganKanan.activeSelf == false && arrowWudhuLenganKiri.activeSelf == false)
						{
							airGayung2.SetActive(false);
						}
					}
					else if ((Vector3.Distance(transform.position, triggerwudhuKakiKiri.position) <= 2))
					{
						arrowWudhuKakiKiri.SetActive(false);
						UnityEngine.Debug.Log("Arrow hilang ");
						curah.SetBool("ambilAir", false);
						curah.SetBool("curah", true);
						curahAir = true;
						kiri.SetBool("wudhu", true);
						kiri.SetBool("idle", false);
						StartCoroutine(timetakenWudhu());

						if (arrowWudhuKakiKanan.activeSelf == false && arrowWudhuKakiKiri.activeSelf == false && arrowWudhuKepala.activeSelf == false && arrowWudhuLenganKanan.activeSelf == false && arrowWudhuLenganKiri.activeSelf == false)
						{
							airGayung2.SetActive(false);
						}
					}
					else if ((Vector3.Distance(transform.position, triggerwudhuKepala.position) <= 2))
					{
						arrowWudhuKepala.SetActive(false);
						UnityEngine.Debug.Log("Arrow hilang ");
						curah.SetBool("ambilAir", false);
						curah.SetBool("curah", true);
						curahAir = true;
						kiri.SetBool("wudhu", true);
						kiri.SetBool("idle", false);
						StartCoroutine(timetakenWudhu());

						if (arrowWudhuKakiKanan.activeSelf == false && arrowWudhuKakiKiri.activeSelf == false && arrowWudhuKepala.activeSelf == false && arrowWudhuLenganKanan.activeSelf == false && arrowWudhuLenganKiri.activeSelf == false)
						{
							airGayung2.SetActive(false);
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
					errorSabun();
					StartCoroutine(unShowInfoErrorSabun());
				}
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////////////// sabun -start- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		// display button
		if (PointerSabun.activeSelf == true) { 
			if (((Vector3.Distance(transform.position, detecter7.position) <= 2) || (Vector3.Distance(transform.position, detecter13.position) <= 2) || (Vector3.Distance(transform.position, detecter8.position) <= 2) || (Vector3.Distance(transform.position, detecter10.position) <= 2) || Vector3.Distance(transform.position, detecter1.position) <= 2) || (Vector3.Distance(transform.position, detecter2.position) <= 2) || (Vector3.Distance(transform.position, detecter4.position) <= 2) || (Vector3.Distance(transform.position, detecter6.position) <= 2) || (Vector3.Distance(transform.position, detecter12.position) <= 2))
			{
				f.SetActive(true);
			}
			else {
				f.SetActive(false);
			}
		}
		
		// process sabun

		if (Input.GetKeyDown(KeyCode.F))
		{


			if (sabunIndicator.activeSelf == false)
			{

				if (((Vector3.Distance(transform.position, detecter7.position) <= 2) || (Vector3.Distance(transform.position, detecter13.position) <= 2) || (Vector3.Distance(transform.position, detecter8.position) <= 2) || (Vector3.Distance(transform.position, detecter10.position) <= 2) || Vector3.Distance(transform.position, detecter1.position) <= 2) || (Vector3.Distance(transform.position, detecter2.position) <= 2) || (Vector3.Distance(transform.position, detecter4.position) <= 2) || (Vector3.Distance(transform.position, detecter6.position) <= 2) || (Vector3.Distance(transform.position, detecter12.position) <= 2))
				{

					//kaki kiri
					if ((Vector3.Distance(transform.position, detecter6.position) <= 2))
					{
						detect.SetActive(true);
						curah.SetBool("sabun", true);
						curah.SetBool("Grabbed", false);
						sabun = true;
						viewBuih.SetActive(true);
						buihKakiKiriStay.SetActive(true);
						buihKakiKiriAnimate.SetActive(true);
						StartCoroutine(buihAnimate());
						arrowSabunMerahKakiKiri.SetActive(false);

						if (buihKakiKiriStay.activeSelf == true && buihKakiKananStay.activeSelf == true && buihTanganKiriStay.activeSelf == true && buihTanganKananStay.activeSelf == true && buihKepalaStay.activeSelf == true)
						{
							notiLetakSabun.SetActive(true);

						}

					}

					//kaki kanan
					if ((Vector3.Distance(transform.position, detecter12.position) <= 2))
					{
						detect.SetActive(true);
						curah.SetBool("sabun", true);
						curah.SetBool("Grabbed", false);
						sabun = true;
						viewBuih.SetActive(true);
						buihKakiKananStay.SetActive(true);
						buihKakiKananAnimate.SetActive(true);
						StartCoroutine(buihAnimate());
						arrowSabunMerahKakiKanan.SetActive(false);

						if (buihKakiKiriStay.activeSelf == true && buihKakiKananStay.activeSelf == true && buihTanganKiriStay.activeSelf == true && buihTanganKananStay.activeSelf == true && buihKepalaStay.activeSelf == true)
						{
							notiLetakSabun.SetActive(true);

						}
					}

					//tanganKiri
					if ((Vector3.Distance(transform.position, detecter2.position) <= 2) || (Vector3.Distance(transform.position, detecter4.position) <= 2))
					{
						detect.SetActive(true);
						curah.SetBool("sabun", true);
						curah.SetBool("Grabbed", false);
						sabun = true;
						viewBuih.SetActive(true);
						buihTanganKiriStay.SetActive(true);
						buihTanganKiriAnimate.SetActive(true);
						StartCoroutine(buihAnimate());
						arrowSabunMerahTanganKiri.SetActive(false);

						if (buihKakiKiriStay.activeSelf == true && buihKakiKananStay.activeSelf == true && buihTanganKiriStay.activeSelf == true && buihTanganKananStay.activeSelf == true && buihKepalaStay.activeSelf == true)
						{
							notiLetakSabun.SetActive(true);

						}
					}

					//tanganKanan
					if ((Vector3.Distance(transform.position, detecter8.position) <= 2) || (Vector3.Distance(transform.position, detecter10.position) <= 2))
					{

						detect.SetActive(true);
						curah.SetBool("sabun", true);
						curah.SetBool("Grabbed", false);
						sabun = true;
						viewBuih.SetActive(true);
						buihTanganKananStay.SetActive(true);
						buihTanganKananAnimate.SetActive(true);
						StartCoroutine(buihAnimate());
						arrowSabunMerahTanganKanan.SetActive(false);

						if (buihKakiKiriStay.activeSelf == true && buihKakiKananStay.activeSelf == true && buihTanganKiriStay.activeSelf == true && buihTanganKananStay.activeSelf == true && buihKepalaStay.activeSelf == true)
						{
							notiLetakSabun.SetActive(true);

						}

					}

					//kepala
					if ((Vector3.Distance(transform.position, detecter13.position) <= 2))
					{

						detect.SetActive(true);
						curah.SetBool("sabun", true);
						curah.SetBool("Grabbed", false);
						sabun = true;
						viewBuih.SetActive(true);
						buihKepalaStay.SetActive(true);
						buihKepalaAnimate.SetActive(true);
						StartCoroutine(buihAnimate());
						arrowSabunMerahKepala.SetActive(false);

						if (buihKakiKiriStay.activeSelf == true && buihKakiKananStay.activeSelf == true && buihTanganKiriStay.activeSelf == true && buihTanganKananStay.activeSelf == true && buihKepalaStay.activeSelf == true)
						{
							notiLetakSabun.SetActive(true);

						}

					}

					if (sabun == true)
					{
						//5 saat
						StartCoroutine(timetakenSabun());
						sabun = false;
					}
				}
				else
				{
					viewBuih.SetActive(false);
					detect.SetActive(false);
				}
			}
			else {

				errorSabun();
				StartCoroutine(unShowInfoErrorSabun());

			}
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////////// tekan perut -start- //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		if (Input.GetKeyDown(KeyCode.Q))
		{
			not_full = true;

			if (angkatIndicator.activeSelf == true)
			{
				if (Vector3.Distance(transform.position, pointerAngkatMayat.position) <= 1)
				{
					notiAngkatJenazah.SetActive(false);
					arrowAngkat.SetActive(false);
					pointerAngkat.SetActive(false);
					//angkat.SetBool("angkat", true);
					mayat.SetBool("mayat", true);
					//body.enabled = true;
					//tanganKanan.transform.SetParent(null);
					mayat.SetBool("mayat", true);
					playIndicator.SetActive(true);
					curah.SetBool("idle", false);
					curah.SetBool("angkatMayatNew", true);
					kiri.SetBool("tekanPerut",true);
					kiri.SetBool("idle", false);
					characterController.enabled = false;
					StartCoroutine(timetakenAngkatMayat());
					
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



		////////////////////////////////////////////////////////////////////////////////////////////////////////// wudhu -Start- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


		if (arrowWudhukanJenazah.activeSelf == true)
		{
			wudhuDetecter.SetActive(true);
		}
		else {
			wudhuDetecter.SetActive(false);
		}

		//if detecter active, display button wudhu, display arrow
		if (wudhuDetecter.activeSelf == true)
		{
			arrowWudhu.SetActive(true);
			if ((Vector3.Distance(transform.position, triggerwudhuTanganKanan.position) <= 2) || (Vector3.Distance(transform.position, triggerwudhuTanganKiri.position) <= 2) || (Vector3.Distance(transform.position, triggerwudhuKakiKanan.position) <= 2) || (Vector3.Distance(transform.position, triggerwudhuKakiKiri.position) <= 2) || (Vector3.Distance(transform.position, triggerwudhuKepala.position) <= 2))
			{
				clickC.SetActive(true);
			}
			else
			{
				clickC.SetActive(false);
			}
		}
		else 
		{
			arrowWudhu.SetActive(false);
		}
		//keyDown Wudhu
		if (Input.GetKeyDown(KeyCode.C)) {

			airCurahan.SetActive(true);
			StartCoroutine(timetakenAirCurahan());

			if (clickC.activeSelf == true && arrowWudhu.activeSelf == true)
			{
				if ((Vector3.Distance(transform.position, triggerwudhuTanganKanan.position) <= 2))
				{
					arrowWudhuLenganKanan.SetActive(false);
					UnityEngine.Debug.Log("Arrow hilang ");
					curah.SetBool("ambilAir", false);
					curah.SetBool("curah", true);
					curahAir = true;
					kiri.SetBool("wudhu", true);
					kiri.SetBool("idle", false);
					StartCoroutine(timetakenWudhu());

					if (arrowWudhuLenganKanan.activeSelf == false && arrowWudhuLenganKiri.activeSelf == false && arrowWudhuKakiKanan.activeSelf == false && arrowWudhuKakiKiri.activeSelf == false && arrowWudhuKepala.activeSelf == false) {

						airGayung2.SetActive(false);
						arrowTualaDisplay.SetActive(true);
					}
				}
				else if ((Vector3.Distance(transform.position, triggerwudhuTanganKiri.position) <= 2))
				{
					arrowWudhuLenganKiri.SetActive(false);
					UnityEngine.Debug.Log("Arrow hilang ");
					curah.SetBool("ambilAir", false);
					curah.SetBool("curah", true);
					curahAir = true;
					kiri.SetBool("wudhu", true);
					kiri.SetBool("idle", false);
					StartCoroutine(timetakenWudhu());

					if (arrowWudhuLenganKanan.activeSelf == false && arrowWudhuLenganKiri.activeSelf == false && arrowWudhuKakiKanan.activeSelf == false && arrowWudhuKakiKiri.activeSelf == false && arrowWudhuKepala.activeSelf == false)
					{

						airGayung2.SetActive(false);
						arrowTualaDisplay.SetActive(true);
					}
				}
				else if ((Vector3.Distance(transform.position, triggerwudhuKakiKanan.position) <= 2))
				{
					arrowWudhuKakiKanan.SetActive(false);
					UnityEngine.Debug.Log("Arrow hilang ");
					curah.SetBool("ambilAir", false);
					curah.SetBool("curah", true);
					curahAir = true;
					kiri.SetBool("wudhu", true);
					kiri.SetBool("idle", false);
					StartCoroutine(timetakenWudhu());

					if (arrowWudhuLenganKanan.activeSelf == false && arrowWudhuLenganKiri.activeSelf == false && arrowWudhuKakiKanan.activeSelf == false && arrowWudhuKakiKiri.activeSelf == false && arrowWudhuKepala.activeSelf == false)
					{

						airGayung2.SetActive(false);
						arrowTualaDisplay.SetActive(true);
					}
				}
				else if ((Vector3.Distance(transform.position, triggerwudhuKakiKiri.position) <= 2))
				{
					arrowWudhuKakiKiri.SetActive(false);
					UnityEngine.Debug.Log("Arrow hilang ");
					curah.SetBool("ambilAir", false);
					curah.SetBool("curah", true);
					curahAir = true;
					kiri.SetBool("wudhu", true);
					kiri.SetBool("idle", false);
					StartCoroutine(timetakenWudhu());

					if (arrowWudhuLenganKanan.activeSelf == false && arrowWudhuLenganKiri.activeSelf == false && arrowWudhuKakiKanan.activeSelf == false && arrowWudhuKakiKiri.activeSelf == false && arrowWudhuKepala.activeSelf == false)
					{

						airGayung2.SetActive(false);
						arrowTualaDisplay.SetActive(true);
					}
				}
				else if ((Vector3.Distance(transform.position, triggerwudhuKepala.position) <= 2))
				{
					arrowWudhuKepala.SetActive(false);
					UnityEngine.Debug.Log("Arrow hilang ");
					curah.SetBool("ambilAir", false);
					curah.SetBool("curah", true);
					curahAir = true;
					kiri.SetBool("wudhu", true);
					kiri.SetBool("idle", false);
					StartCoroutine(timetakenWudhu());

					if (arrowWudhuLenganKanan.activeSelf == false && arrowWudhuLenganKiri.activeSelf == false && arrowWudhuKakiKanan.activeSelf == false && arrowWudhuKakiKiri.activeSelf == false && arrowWudhuKepala.activeSelf == false)
					{

						airGayung2.SetActive(false);
						arrowTualaDisplay.SetActive(true);
					}
				}
				else {

					errorSabun();
					StartCoroutine(unShowInfoErrorSabun());

				}

			}
			else {
				errorSabun();
				StartCoroutine(unShowInfoErrorSabun());
			}
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////////// wudhu -end- ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


		////////////////////////////////////////////////////////////////////////////////////////////////////////// display Text E -start- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		if (Vector3.Distance(transform.position, pointerAngkatMayat.position) <= 1)
		{
			buttonE.SetActive(true);
		}
		else{
			buttonE.SetActive(false);
		}
		////////////////////////////////////////////////////////////////////////////////////////////////////////// display Text E -end- //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


		////////////////////////////////////////////////////////////////////////////////////////////////////////// display text R -start- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		if (triggerLap.activeSelf == true) {
			if ((Vector3.Distance(transform.position, triggerLapKepala.position) <= 2) || (Vector3.Distance(transform.position, triggerLapTanganKiri.position) <= 2) || (Vector3.Distance(transform.position, triggerLapTanganKanan.position) <= 2) || (Vector3.Distance(transform.position, triggerLapKakiKiri.position) <= 2) || (Vector3.Distance(transform.position, triggerLapKakiKanan.position) <= 2))
			{
				buttonR.SetActive(true);
			}
			else
			{
				buttonR.SetActive(false);
			}
		}
		


		////////////////////////////////////////////////////////////////////////////////////////////////////////// lap jenazah -start- ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


		if (Input.GetKeyDown(KeyCode.R)) 
		{

			if (arrowLapJenazah.activeSelf == true)
			{

				if ((Vector3.Distance(transform.position, triggerLapKepala.position) <= 2) && buttonR.activeSelf == true)
				{
					curah.SetBool("grabtuala", false);
					curah.SetBool("lapjenazah", true);
					kiri.SetBool("lap", true);
					kiri.SetBool("idle", false);
					StartCoroutine(backToGrabTuala());
					StartCoroutine(arrowLapKepalaHijau());
				}
				else if ((Vector3.Distance(transform.position, triggerLapTanganKiri.position) <= 2) && buttonR.activeSelf == true)
				{
					curah.SetBool("grabtuala", false);
					curah.SetBool("lapjenazah", true);
					kiri.SetBool("lap", true);
					kiri.SetBool("idle", false);
					StartCoroutine(backToGrabTuala());
					StartCoroutine(arrowLapTanganKiriHijau());
				}
				else if ((Vector3.Distance(transform.position, triggerLapTanganKanan.position) <= 2) && buttonR.activeSelf == true)
				{
					curah.SetBool("grabtuala", false);
					curah.SetBool("lapjenazah", true);
					kiri.SetBool("lap", true);
					kiri.SetBool("idle", false);
					StartCoroutine(backToGrabTuala());
					StartCoroutine(arrowLapTanganKananHijau());
				}
				else if ((Vector3.Distance(transform.position, triggerLapKakiKiri.position) <= 2) && buttonR.activeSelf == true)
				{
					curah.SetBool("grabtuala", false);
					curah.SetBool("lapjenazah", true);
					kiri.SetBool("lap", true);
					kiri.SetBool("idle", false);
					StartCoroutine(backToGrabTuala());
					StartCoroutine(arrowLapKakiKiriHijau());
				}
				else if ((Vector3.Distance(transform.position, triggerLapKakiKanan.position) <= 2) && buttonR.activeSelf == true)
				{
					curah.SetBool("grabtuala", false);
					curah.SetBool("lapjenazah", true);
					kiri.SetBool("lap", true);
					kiri.SetBool("idle", false);
					StartCoroutine(backToGrabTuala());
					StartCoroutine(arrowLapKakiKananHijau());
				}
				else
				{
					errorSabun();
					StartCoroutine(unShowInfoErrorSabun());
				}
			}
			else {
				infoErrorSabun.SetActive(true);
				StartCoroutine(unShowInfoErrorSabun());
			}
		}



		////////////////////////////////////////////////////////////////////////////////////////////////////////// SC_FPS Controller -start- /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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

		////////////////////////////////////////////////////////////////////////////////////////////////////////// SC_FPS Controller -end- /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	}



	public GameObject arrowAngkat;
	public GameObject pointerAngkat;
	public GameObject infoErrorSabun;

	public void errorSabun() {

		infoErrorSabun.SetActive(true);

	}


   



    // if arrow merah semua dah hilang
    // then bila release gayung, muncul arrow kat atas mayat untuk next step(angkat mayat)




    //gerakKePointer
    public void moveToPointer() {
		
		characterController.enabled = false;

		while (transform.position != pointer.position)
		{
			transform.position = Vector3.MoveTowards(transform.position, pointer.position, Targetspeed * Time.deltaTime);

		}
		
			
		UnityEngine.Debug.Log("Move to pointer");
		
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
				ambilBarangButton.SetActive(true);
			}
			else oldSabun.unshowText();
			ambilBarangButton.SetActive(false);
		}
	}


	public bool textGayung = false;
	
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
				
				ambilBarangButton.SetActive(true);
				textGayung = true;
				leftClick.SetActive(true);

				
			}
			else
			{
				oldGayung.unshowTextGayung();
				ambilBarangButton.SetActive(false);
				textGayung = false;
				leftClick.SetActive(false);

			}
				
		}
	}

	public void showTextGayungBilasSabun()
	{

		RaycastHit detect;

		UnityEngine.Debug.Log("NamaGayungBilasSabun");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{
			gayungBaru gayungBilasSabun = detect.transform.GetComponent<gayungBaru>();
			if (gayungBilasSabun != null)
			{
				oldGayungBilasSabun = gayungBilasSabun;
				gayungBilasSabun.showTextGayung();
				;
				ambilBarangButton.SetActive(true);
				textGayung = true;
			}
			else
			{
				oldGayungBilasSabun.unshowTextGayung();
				ambilBarangButton.SetActive(false);
				textGayung = false;
			}
		}
	}

	public gayungWudhu oldGayungWudhu = null;

	public void showTextGayungWudhu()
	{

		RaycastHit detect;

		UnityEngine.Debug.Log("NamaGayungWudhu");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{
			gayungWudhu gayungWudhu = detect.transform.GetComponent<gayungWudhu>();
			if (gayungWudhu != null)
			{
				oldGayungWudhu = gayungWudhu;
				gayungWudhu.showTextGayung();
				
				ambilBarangButton.SetActive(true);
				textGayung = true;
			}
			else
			{
				oldGayungWudhu.unshowTextGayung();
				ambilBarangButton.SetActive(false);
				textGayung = false;
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
				ambilBarangButton.SetActive(true);
			}
			else oldSarungTangan.unshowNamaGlove();
			ambilBarangButton.SetActive(false);
		}
	}

	public INTR_SarungTangan2 oldSarungTangan2 = null;

	public void showTextGlove2()
	{

		RaycastHit detect;

		UnityEngine.Debug.Log("NamaGlove2");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{

			INTR_SarungTangan2 glove2 = detect.transform.GetComponent<INTR_SarungTangan2>();
			if (glove2 != null)
			{
				oldSarungTangan2 = glove2;
				glove2.showNamaGlove();
				ambilBarangButton.SetActive(true);
			}
			else oldSarungTangan2.unshowNamaGlove();
			
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

		UnityEngine.Debug.Log("Text Air Paip");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{

			INTR_Baldi baldi = detect.transform.GetComponent<INTR_Baldi>();
			if (baldi != null)
			{
				
				oldAir = baldi;
				baldi.showTextAir();
				nakAmbil = true;
				cedokButton.SetActive(true);
			}
			else oldAir.unshowTextAir();
			cedokButton.SetActive(false);
			//nakAmbil = false;
		}
	}

	public INTR_Tuala2 oldTuala = null;
	public INTR_TongSampah oldTongSampah = null;

	
	public void showTextTuala()
	{

		RaycastHit detect;

		UnityEngine.Debug.Log("TextTuala");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{

			INTR_Tuala2 tuala = detect.transform.GetComponent<INTR_Tuala2>();
			if (tuala != null)
			{
				UnityEngine.Debug.Log("TextTuala2");
				oldTuala = tuala;
				tuala.showNamaTuala();
				leftClick.SetActive(true);

			}
			else oldTuala.unshowNamaTuala();
			leftClick.SetActive(false);
			//nakAmbil = false;
		}
	}

	public void showTextTongSampah()
	{

		RaycastHit detect;

		UnityEngine.Debug.Log("Text Tong Sampah");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{

			INTR_TongSampah tongSampah = detect.transform.GetComponent<INTR_TongSampah>();
			if (tongSampah != null)
			{

				oldTongSampah = tongSampah;
				tongSampah.showNamaTongSampah();

			}
			else oldTongSampah.unshowNamaTongSampah();
			//nakAmbil = false;
		}
	}

	public nextButton oldNextButton = null;
	public void nextButton1()
	{
		RaycastHit detect;
		UnityEngine.Debug.Log("detect button");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{
			nextButton next = detect.transform.GetComponent<nextButton>();
			if (next != null)
			{
				oldNextButton = next;
				next.greenOn();
			}
			else oldNextButton.greenOff();
		}
	}

	
	public trueButton oldQ1True;

	public void Q1trueHover()
	{
		RaycastHit detect;
		UnityEngine.Debug.Log("hover true Q1");
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detect, range))
		{
			trueButton Q1True = detect.transform.GetComponent<trueButton>();
			if (Q1True != null)
			{
				oldQ1True = Q1True;
				Q1True.yellowOn();
			}
			else oldQ1True.yellowOff();
		}
	}


	public bool pegangGayung = false;
	public bool pegangGayung2 = false;
	public bool pegangSabun = false;

	public void interactTuala() {
		tuala.grab();
	}

	public GameObject greenButton;
	public GameObject pg1;
	public GameObject pg2;
	public GameObject pg3;

	public void interactItem() {

		RaycastHit detect;
		UnityEngine.Debug.Log("detect");
		if (Physics.Raycast(playerCamera.transform.position,playerCamera.transform.forward,out detect, range)) {

				//check tangan full atau tak
				//not_full == true
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
						pegangGayung = true;
						//gayungIndicator.SetActive(true);
					}

					gayungBaru gayungBilasSabun = detect.transform.GetComponent<gayungBaru>();

					if (gayungBilasSabun != null)
					{
						gayungBilasSabun.grab();
						UnityEngine.Debug.Log("amik gayung 2");
						//kanan.pegangGayung();
						curah.SetBool("Grabbed",true);
						curah.SetBool("idle", false);
						pegangGayung2 = true;
						pegangGayung = false;
						not_full = false;
						//gayungIndicator.SetActive(true);
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

					INTR_SarungTangan2 glove2 = detect.transform.GetComponent<INTR_SarungTangan2>();
					if (glove2 != null)
					{
						glove2.grab();
						//not_full = false;
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


			if (!not_full) { 
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

	public void releaseObject() {

		if (!not_full) {


			if (pegangGayung == true)
			{
				releaseGayung.release();
				idleHand.SetBool("idle", true);
				idleHand.SetBool("Grabbed", false);

				not_full = true;
				pegangGayung = false;
			}
			else
			{

				releaseSabun.release();
				idleHand.SetBool("GrabSabun", false);
				not_full = true;
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
					UnityEngine.Debug.Log("cedok basuhan pertama");
					kanan.cedok();
					ambilAir = true;
					air.showAir();
					unShowArrowAir();
					showArrowProcess();
					not_full = false;
				}
		}
	}


	public void cedokAirBilasSabun()
	{
		RaycastHit detectBaldi;
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detectBaldi, range))
		{

			INTR_Baldi baldi = detectBaldi.transform.GetComponent<INTR_Baldi>();

			if (baldi != null)
			{
				UnityEngine.Debug.Log("cedok bilas sabun");
				kanan.cedok();
				ambilAir = true;
				arrowAmbilairBilasSabun.SetActive(false);
				airBilasSabun.SetActive(true);
				not_full = false;
			}

				
		}
	}

	public void cedokAirWudhu()
	{
		RaycastHit detectBaldi;
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out detectBaldi, range))
		{

			INTR_Baldi baldi = detectBaldi.transform.GetComponent<INTR_Baldi>();

			if (baldi != null)
			{
				UnityEngine.Debug.Log("cedok wudhu");
				kanan.cedok();
				ambilAir = true;
				arrowCedokAirWudhu.SetActive(false);
				airBilasSabun.SetActive(true);
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

	public void stopTunduk() {

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




	public void showButtonCurah() {

		if (arrowSiram.activeSelf == true)
		{
			if ((Vector3.Distance(transform.position, detecterSiramTanganKanan.position) <= 2) || (Vector3.Distance(transform.position, detecterSiramTanganKiri.position) <= 2) || (Vector3.Distance(transform.position, detecterSiramKakiKanan.position) <= 2) || (Vector3.Distance(transform.position, detecterSiramKakiKiri.position) <= 2))
			{
				curahButton.SetActive(true);
			}
			else
			{
				curahButton.SetActive(false);
			}
		}

	}




}

