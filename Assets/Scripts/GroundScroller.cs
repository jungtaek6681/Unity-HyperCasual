using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
	public GameObject[] grounds;
	public float moveSpeed;

	public void Update()
	{
		for (int i = 0; i < grounds.Length; i++)
		{
			grounds[i].transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);

			if (grounds[i].transform.position.x < -7)
			{
				grounds[i].transform.Translate(Vector3.right * 14, Space.World);
			}
		}
	}


}
