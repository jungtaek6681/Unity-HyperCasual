using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
	public float moveSpeed;

	private void Update()
	{
		transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

		if (transform.position.x < -5)
			Destroy(gameObject);
	}
}
