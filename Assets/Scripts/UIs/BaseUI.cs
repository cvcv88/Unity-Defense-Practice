using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseUI : MonoBehaviour
{
    // protected Dictionary<string, RectTransform> transforms;
	// ��� ���ӿ�����Ʈ�� transform ������Ʈ�� ���� �ִ�.
	// �� �� UI�� ��� RectTransfrom�� ���� �ִ�.
	// protected Dictionary<string, Button> buttons;
	// protected Dictionary<string, TMP_Text> texts;
	// TODO : add ui compoenent

	Dictionary<string, Component> components;
	public Component[] children;

	protected virtual void Awake()
	{
		Debug.Log("Binding");
		Bind(); // ���ε�
	}

	private void Bind()
	{
		/*transforms = new Dictionary<string, RectTransform>();
		buttons = new Dictionary<string, Button>();
		texts = new Dictionary<string, TMP_Text>();

		// ��� �ڽĵ��� transform�� ��������
		RectTransform[] children = GetComponentsInChildren<RectTransform>();
		// InChildren : �ڽĵ���� �����ؼ� ������Ʈ ã��
		// s : BaseUI �������� ��� ������Ʈ ã�� 

		// ��� �ڽ� ��ȸ�ϸ鼭 ��������
		foreach(RectTransform child in children)
		{
			// ���ӿ�����Ʈ�� �̸��� ��������
			string name = child.gameObject.name;

			if (transforms.ContainsKey(name))
				continue;

			transforms.Add(name, child);

			// ��ư������Ʈ ã�ƺ���
			// ���� ��ư������Ʈ�� null�� �ƴϸ�
			// ��ư�� ��ųʸ��� �߰��Ѵ�
			Button button = child.GetComponent<Button>();
			if(button != null)
			{
				buttons.Add(name, button);
			}

			// null�� �ƴϸ� �ؽ�Ʈ�� ��ųʸ��� �߰��Ѵ� : ���ε�
			TMP_Text text = child.GetComponent<TMP_Text>();
			if(text != null)
			{
				texts.Add(name, text);
			}
		}*/

		// ��� ������Ʈ�� ã��
		components = new Dictionary<string, Component>();
		children = GetComponentsInChildren<Component>();

		// �Ϲ�ȭ���Ѽ� ã��
		foreach(Component child in children)
		{
			string name = $"{child.gameObject.name}_{child.GetType().Name}"; // ���ӿ�����Ʈ�� �̸��� ������Ʈ�� �̸��� ���� �־��ֱ�
																			 // next ��ư�� transform ������Ʈ..
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
