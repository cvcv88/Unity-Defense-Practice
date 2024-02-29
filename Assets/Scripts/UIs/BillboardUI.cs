using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardUI : BaseUI
{
	private void LateUpdate()
	{
		transform.forward = Camera.main.transform.forward;
		// 게임오브젝트의 앞방향이 카메라가 바라보는 방향으로 만들어주기
	}
}
