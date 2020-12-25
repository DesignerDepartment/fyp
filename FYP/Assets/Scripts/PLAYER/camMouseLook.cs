using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMouseLook : MonoBehaviour
{
	Vector2 mouseLook; Vector2 smoothV;
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;

	GameObject character;

	private Animator playCamera;

	public GameObject playIndicator;

	void Start()
	{
		playCamera = GetComponent<Animator>();
		character = this.transform.parent.gameObject;
		playCamera.enabled = false;
		playIndicator.SetActive(false);
	}

	void Update()
	{
		var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

		md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing); 
		smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing); mouseLook += smoothV;

		transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

		if (playIndicator.activeSelf == true) {

			playCamera.enabled = true;
			StartCoroutine(cameraPlayTimer());

		}

	}

	IEnumerator cameraPlayTimer()
	{
		//Print the time of when the function is first called.
		UnityEngine.Debug.Log("Start noti gayung");
		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(23);
		playIndicator.SetActive(false);
		playCamera.enabled = false;
		//After we have waited 5 seconds print the time again.
		UnityEngine.Debug.Log("Start noti gayung");
	}

}

