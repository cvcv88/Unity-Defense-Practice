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
		// transform �������ָ� �ι�° �Ű������� �θ��� �ڽ����� ���� �ȴ�.

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
			// ������ �˾� �����ͼ� Ȱ��ȭ ��Ű��
			PopUpUI prevUI = popUpStack.Peek();
			prevUI.gameObject.SetActive(true);
		}
		else
		{
			// ��� �˾� �� ������ ��
			Time.timeScale = 1f;
			popUpBlocker.gameObject.SetActive(false);
		}
	}

	public void CloseAllPopUP()
	{
		while(popUpStack.Count > 0) // ���ÿ� �������� 0�� �ɶ����� ��� �˾� �ݱ�
		{
			ClosePopUpUI();
		}
	}

	public T ShowWindowUI<T>(T windowUI) where T : WindowUI
	{
		T ui = Instantiate(windowUI, windowCanvas.transform); // windowUI �������� ������ windowCanvas�� �ڽ����� Instantiate ���ֱ�
		return ui;
	}

	public void CloseWindowUI<T>(T windowUI) where T : WindowUI
	{
		Destroy(windowUI.gameObject); // 3:57���ͺ���
	}

	public void SelectWindowUI(WindowUI windowUI)
	{
		// WindowUI ������ �� �������� �ű��
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
