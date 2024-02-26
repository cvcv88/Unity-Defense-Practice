using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
	// �ֱ������� ���� �����ϱ�

	[SerializeField] Transform startPoint;
	[SerializeField] Transform endPoint;
    [SerializeField] Monster monsterPrefab;
	[SerializeField] float repeatTime; // monsterPrefab�� repeatTime ��ŭ �ݺ������� ��������

	private void OnEnable()
	{
		spawnerRoutine = StartCoroutine(SpawnerRoutine());
	}

	private void OnDisable()
	{
		StopCoroutine(spawnerRoutine);
	}

	Coroutine spawnerRoutine;
	IEnumerator SpawnerRoutine()
	{
		while (true)
		{

		}
	}

}
