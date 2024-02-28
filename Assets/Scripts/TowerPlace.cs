using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Scripting;

public class TowerPlace : MonoBehaviour
	, IPointerClickHandler
	, IPointerEnterHandler
	, IPointerExitHandler
	, IPointerUpHandler
	, IPointerDownHandler
	, IPointerMoveHandler
{
	/*
	public void OnRightClick(InputValue value)
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, out RaycastHit hitInfo);
		hitInfo.collider.GetComponent<OnPointerClick>();
	}
	-> OnPointerClick()
	*/

	// public UnityEvent OnPointerEntered;
	// public UnityEvent OnPointerExited;

	[SerializeField] Renderer render;
	[SerializeField] Color normalColor;
	[SerializeField] Color hightlightColor;

	[SerializeField] InGameUI buildUI;
	public void OnPointerClick(PointerEventData eventData)
	{
		// Debug.Log("Click");
		InGameUI ui = Manager.UI.ShowInGameUI(buildUI);
		ui.SetTarget(transform);
		ui.SetOffset(new Vector3(0, 100, 0));
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		// Debug.Log("Down");
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("Enter");
		//OnPointerEntered?.Invoke();
		render.material.color = hightlightColor;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("Exit");
		//OnPointerExited?.Invoke();
		render.material.color = normalColor;
	}

	public void OnPointerMove(PointerEventData eventData)
	{
		// Debug.Log("Move");
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		// Debug.Log("Up");
	}
}
