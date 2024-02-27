using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
	[SerializeField] EventSystem eventSystemPrefab;

	private Stack<PopUpUI> popUpStack;

	private void Awake()
	{
		EnsureEventSystem();
	}

	public void EnsureEventSystem()
	{
		EventSystem eventSystem = FindObjectOfType<EventSystem>();
		if(eventSystem == null)
		{
			Instantiate(eventSystemPrefab);
		}
	}
	public T ShowPopUpUI<T>(T popUpUI) where T: PopUpUI
	{
		if(popUpStack.Count > 0)
		{
			PopUpUI prevUI = popUpStack.Peek();
			prevUI.gameObject.SetActive(false);
		}

		T instance = Instantiate(popUpUI);
		popUpStack.Push(instance);
		Time.timeScale = 0f;

		return instance;
	}

	public void ClosePopUpUI()
	{
		PopUpUI curUI = popUpStack.Pop();
		Destroy(curUI.gameObject);

		if(popUpStack.Count > 0)
		{
			// 이전의 팝업 가져와서 활성화 시키기
			PopUpUI prevUI = popUpStack.Peek();
			prevUI.gameObject.SetActive(true);
		}
		else
		{
			// 모든 팝업 다 닫혔을 때
			Time.timeScale = 1f;
		}
	}
}
