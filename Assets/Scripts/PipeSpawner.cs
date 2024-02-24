using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] PipeMover pipePrefab;
    [SerializeField] float spawnTime;
    [SerializeField] float pipeSpeed;
    [SerializeField] float randomRange;

    Coroutine spawnRoutine;

    private void OnEnable()
    {
        spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(spawnRoutine);
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Vector2 spawnPos = transform.position + Vector3.up * Random.Range(-randomRange, randomRange);
            PipeMover pipeMover = Instantiate(pipePrefab, spawnPos, transform.rotation);
            pipeMover.MoveSpeed = pipeSpeed;
        }
    }
}
