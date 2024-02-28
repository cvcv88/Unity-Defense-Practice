using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : BaseUI
{
    // 게임오브젝트를 따라서 움직이는 UI 만들기
    public Transform followTarget;
	public Vector3 followOffset;

	private void LateUpdate()
	{
		// 1. 잘못된 방법
		// UI와 게임오브젝트 빌드 포인트 간의 격차가 너무 크다.
		// transform.position = followTarget.position;
		if (followTarget == null)
			return;
		transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + followOffset;
	}

	public void SetTarget(Transform target)
	{
		followTarget = target;
	}

	public void SetOffset(Vector3 offset)
	{
		followOffset = offset;
	}
}
