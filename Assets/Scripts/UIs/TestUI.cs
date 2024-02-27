using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : BaseUI
{
	protected override void Awake()
	{
		base.Awake(); // 바인딩 과정 진행에 필요

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

		// 사용방법
		// UI 중에서 이름이 "Name"인 게임오브젝트에서 컴포넌트 Button을 갖다 쓰고 싶다.
		// GetUI<Button>("Name");
	}
}
