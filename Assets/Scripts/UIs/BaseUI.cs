using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseUI : MonoBehaviour
{
    // protected Dictionary<string, RectTransform> transforms;
	// 모든 게임오브젝트는 transform 컴포넌트를 갖고 있다.
	// 그 중 UI는 모두 RectTransfrom을 갖고 있다.
	// protected Dictionary<string, Button> buttons;
	// protected Dictionary<string, TMP_Text> texts;
	// TODO : add ui compoenent

	Dictionary<string, Component> components;
	public Component[] children;

	protected virtual void Awake()
	{
		Debug.Log("Binding");
		Bind(); // 바인딩
	}

	private void Bind()
	{
		/*transforms = new Dictionary<string, RectTransform>();
		buttons = new Dictionary<string, Button>();
		texts = new Dictionary<string, TMP_Text>();

		// 모든 자식들의 transform을 저장하자
		RectTransform[] children = GetComponentsInChildren<RectTransform>();
		// InChildren : 자식들까지 포함해서 컴포넌트 찾기
		// s : BaseUI 기준으로 모든 컴포넌트 찾기 

		// 모든 자식 순회하면서 참조하자
		foreach(RectTransform child in children)
		{
			// 게임오브젝트의 이름을 기준으로
			string name = child.gameObject.name;

			if (transforms.ContainsKey(name))
				continue;

			transforms.Add(name, child);

			// 버튼컴포넌트 찾아보고
			// 만약 버튼컴포넌트가 null이 아니면
			// 버튼을 딕셔너리에 추가한다
			Button button = child.GetComponent<Button>();
			if(button != null)
			{
				buttons.Add(name, button);
			}

			// null이 아니면 텍스트를 딕셔너리에 추가한다 : 바인딩
			TMP_Text text = child.GetComponent<TMP_Text>();
			if(text != null)
			{
				texts.Add(name, text);
			}
		}*/

		// 모든 컴포넌트들 찾기
		components = new Dictionary<string, Component>();
		children = GetComponentsInChildren<Component>();

		// 일반화시켜서 찾기
		foreach(Component child in children)
		{
			string name = $"{child.gameObject.name}_{child.GetType().Name}"; // 게임오브젝트의 이름과 컴포넌트의 이름도 같이 넣어주기
																			 // next 버튼의 transform 컴포넌트..
			if (components.ContainsKey(name))
				continue;
			components.Add(name, child);
			// Debug.Log(name); 
		}
	}
	public T GetUI<T>(string name) where T : Component
	{
		return components[$"{name}_{typeof(T).Name}"] as T;
	}
}
