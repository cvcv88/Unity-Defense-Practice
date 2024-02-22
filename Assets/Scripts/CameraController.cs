using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
	[SerializeField] float moveSpeed;
	[SerializeField] float padding;
	private Vector3 moveDir;

	private void OnEnable()
	{
		Cursor.lockState = CursorLockMode.Confined;
	}
	private void OnDisable()
	{
		Cursor.lockState = CursorLockMode.None;
	}

	private void Update()
	{
		Move();
	}

	private void Move()
	{
		transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
	}

	private void OnMove(InputValue value)
	{
		Vector2 input = value.Get<Vector2>();
		moveDir.x = input.x;
		moveDir.z = input.y;
	}

	private void OnPointer(InputValue value)
	{
		Vector2 input = value.Get<Vector2>();

		if (input.x < padding)
		{
			moveDir.x = -1;
		}
		else if (Screen.width - padding < input.x)
		{
			moveDir.x = 1;
		}
		else
		{
			moveDir.x = 0;
		}

		if (input.y < padding)
		{
			moveDir.z = -1;
		}
		else if (Screen.height - padding < input.y)
		{
			moveDir.z = 1;
		}
		else
		{
			moveDir.z = 0;
		}
	}
}
