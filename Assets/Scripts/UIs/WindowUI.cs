using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowUI : BaseUI, IDragHandler, IPointerDownHandler
{
	public void OnDrag(PointerEventData eventData)
	{
		// ��ȭ�� ��ŭ Translate ���ش�.
		// ������ 1. ���� �׷��� ����� �׻� �ڿ� �ڸ��Ѵ�, ��������.
		// �ذ�� 1. Ŭ���� ����� SetAsLastSibling���� ���߿� ������� ��ó�� ������ �ٲ۴�.
		transform.Translate(eventData.delta);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		// �����ڸ��� �ٲ�⸦ ���ϱ� ������ Down
		// �� this �����ϱ�
		Manager.UI.SelectWindowUI(this);
	}
}
