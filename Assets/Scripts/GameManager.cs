using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager instance = null;

	public PlayerController playerController;
	public Animator uiAnimator;
	public GameObject pipeSpawner;
	public float moveSpeed;
	public bool isStarted = false;

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

	public void StartGame()
	{
		playerController.StartFly();
		uiAnimator.SetBool("Start", true);
		pipeSpawner.SetActive(true);
	}

	public void SetPause(bool pause)
	{
		Time.timeScale = pause ? 0f : 1f;
	}

}
