using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowUI : BaseUI, IDragHandler, IPointerDownHandler
{
	public void OnDrag(PointerEventData eventData)
	{
		// 변화량 만큼 Translate 해준다.
		// 문제점 1. 먼저 그려진 대상이 항상 뒤에 자리한다, 가려진다.
		// 해결법 1. 클릭한 대상을 SetAsLastSibling으로 나중에 만들어진 것처럼 순서를 바꾼다.
		transform.Translate(eventData.delta);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		// 누르자마자 바뀌기를 원하기 때문에 Down
		// 나 this 선택하기
		Manager.UI.SelectWindowUI(this);
	}
}
