using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform endPoint;

	/*private void Start() // endPoint로 자동이동
	{
		agent.destination = endPoint.position;
	}*/

	private void MoveTo(Vector3 point)
    {
        agent.destination = point;
    }

	private void OnRightClick(InputValue value)
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out RaycastHit hitInfo))
		{
			Debug.DrawLine(Camera.main.transform.position, hitInfo.point, Color.red, 0.2f);
			MoveTo(hitInfo.point);
		}
	}
}
