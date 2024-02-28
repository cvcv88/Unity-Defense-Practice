using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField] EventSystem eventSystemPrefab;

	[Header("PopUP")]
	[SerializeField] Canvas popUpCanvas;
	[SerializeField] Image popUpBlocker;

	[Header("Window")]
	[SerializeField] Canvas windowCanvas;

	[Header("InGame")]
	[SerializeField] Canvas inGameCanvas;
	[SerializeField] Button inGameBlocker;

	private Stack<PopUpUI> popUpStack = new Stack<PopUpUI>();
	private Stack<InGameUI> inGameStack = new Stack<InGameUI>();

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

		// T instance = Instantiate(popUpUI);
		T instance = Instantiate(popUpUI, popUpCanvas.transform);
		// transform 지정해주면 두번째 매개변수가 부모인 자식으로 들어가게 된다.

		popUpStack.Push(instance);
		Time.timeScale = 0f;
		popUpBlocker.gameObject.SetActive(true);

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
			popUpBlocker.gameObject.SetActive(false);
		}
	}

	public void CloseAllPopUP()
	{
		while(popUpStack.Count > 0) // 스택에 남은것이 0이 될때까지 모든 팝업 닫기
		{
			ClosePopUpUI();
		}
	}

	public T ShowWindowUI<T>(T windowUI) where T : WindowUI
	{
		T ui = Instantiate(windowUI, windowCanvas.transform); // windowUI 프리팹을 가지고 windowCanvas의 자식으로 Instantiate 해주기
		return ui;
	}

	public void CloseWindowUI<T>(T windowUI) where T : WindowUI
	{
		Destroy(windowUI.gameObject); // 3:57부터보기
	}

	public void SelectWindowUI(WindowUI windowUI)
	{
		// WindowUI 눌렀을 때 계층구조 옮기기
		windowUI.transform.SetAsLastSibling();
	}

	public T ShowInGameUI<T>(T inGameUI) where T : InGameUI
	{
		T ui = Instantiate(inGameUI, inGameCanvas.transform);
		inGameStack.Push(ui);
		inGameBlocker.gameObject.SetActive(true);
		return ui;
	}

	public void CloseInGameUI()
	{
		if(inGameStack.Count > 0)
		{
			InGameUI inGameUI = inGameStack.Pop();
			Destroy(inGameUI.gameObject);
		}

		if(inGameStack.Count == 0)
		{
			inGameBlocker.gameObject.SetActive(false);
		}
	}
}
