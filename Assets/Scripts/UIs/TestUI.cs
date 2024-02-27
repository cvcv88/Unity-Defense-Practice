using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : BaseUI
{
	protected override void Awake()
	{
		base.Awake(); // ���ε� ���� ���࿡ �ʿ�

		// Debug.Log("TestUI");
		// texts["Title"].text = "Title";
		// texts["Title"].text = "Ending";
		// buttons["NextButton"].interactable = false;

		Button button = GetUI<Button>("NextButton");
		GetUI<Button>("NextButton").interactable = false;

		TMP_Text titleText = GetUI<TextMeshProUGUI>("Title");
		GetUI<TextMeshProUGUI>("Title").text = "<Title>";

		// GetUI<RectTransform>("PlayerImage").position = new Vector2(100, 0);
		GetUI<Image>("PlayerImage").color = Color.red;

		// �����
		// UI �߿��� �̸��� "Name"�� ���ӿ�����Ʈ���� ������Ʈ Button�� ���� ���� �ʹ�.
		// GetUI<Button>("Name");
	}
}
