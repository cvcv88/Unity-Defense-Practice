using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : PopUpUI
{
	[SerializeField] ShutCutUI ShutCutUIPrefab;
	protected override void Awake()
	{
		base.Awake();

		GetUI<Button>("ShutCutButton").onClick.AddListener(ShotCut);
		GetUI<Button>("CloseButton").onClick.AddListener(Close);
	}

	public void ShotCut()
	{
		Manager.UI.ShowPopUpUI(ShutCutUIPrefab);
	}
}
