using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : BaseUI
{
    // ���ӿ�����Ʈ�� ���� �����̴� UI �����
    public Transform followTarget;
	public Vector3 followOffset;

	private void LateUpdate()
	{
		// 1. �߸��� ���
		// UI�� ���ӿ�����Ʈ ���� ����Ʈ ���� ������ �ʹ� ũ��.
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
