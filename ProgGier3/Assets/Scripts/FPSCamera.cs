using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{

	public float mouseSensitivityX = 1.0f;
	private float rotationX = 0f;

	public float walkSpeed = 10.0f;
	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;

	 private Rigidbody rigidbodyR;

	public AudioSource footsteps;
	private Vector3 lastPos;

	void Start()
	{
		rigidbodyR = GetComponent<Rigidbody>();

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		// rotation
		rotationX += Input.GetAxis("Mouse X") * mouseSensitivityX;
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationX, transform.localEulerAngles.z);

		// movement
		Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
		Vector3 targetMoveAmount = moveDir * walkSpeed;
		moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

	}

	void FixedUpdate()
	{
		rigidbodyR.MovePosition(rigidbodyR.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);

		if (lastPos != transform.position)
		{
			footsteps.volume = 0.5f;
		}
		else
		{
			footsteps.volume = 0;

		}

		lastPos = transform.position;
	}

}

