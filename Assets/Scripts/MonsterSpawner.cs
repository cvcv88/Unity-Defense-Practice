using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
	// 주기적으로 몬스터 생성하기

	[SerializeField] Transform startPoint;
	[SerializeField] Transform endPoint;
    [SerializeField] Monster monsterPrefab;
	[SerializeField] float repeatTime; // monsterPrefab을 repeatTime 만큼 반복적으로 생성하자

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
