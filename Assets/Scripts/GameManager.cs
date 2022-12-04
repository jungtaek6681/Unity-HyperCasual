using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager instance = null;

	public float moveSpeed;

	private GameManager()
	{
		instance = this;
	}

	public static GameManager Instance
	{
		get
		{
			if (instance != null) return instance;
			else return new GameManager();
		}
		private set
		{
			instance = value;
		}
	}

}
