using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardUI : BaseUI
{
	private void LateUpdate()
	{
		transform.forward = Camera.main.transform.forward;
		// ���ӿ�����Ʈ�� �չ����� ī�޶� �ٶ󺸴� �������� ������ֱ�
	}
}
