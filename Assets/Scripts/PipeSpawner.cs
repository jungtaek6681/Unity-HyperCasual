using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
	public GameObject pipe;
	public Transform spawnPosition;
	public float repeatTime;
	public float randomRange;

	Coroutine spawnRoutine;

	private void OnEnable()
	{
		spawnRoutine = StartCoroutine(SpawnFunc());
	}

	private void OnDisable()
	{
		StopCoroutine(spawnRoutine);
	}

	private IEnumerator SpawnFunc()
	{
		while (true)
		{
			yield return new WaitForSeconds(repeatTime);
			float random = Random.Range(-1 * randomRange, 1 * randomRange);
			Instantiate(pipe, spawnPosition.position + new Vector3(0, random, 0), spawnPosition.rotation);
		}
	}
}
