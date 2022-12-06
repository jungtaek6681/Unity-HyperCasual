using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum GameState { Ready, Play, Pause, End }

public class GameManager : MonoBehaviour
{
	public PlayerController playerController;
	public GameObject pipeSpawner;
	public UIManager uiManager;

	private int bestScore = 0;
	private int score = 0;

	private void Start()
	{
		ReadyGame();
	}

	public void ReadyGame()
	{
		SetPause(false);

		uiManager.ReadyGame();
		playerController.SetGravity(false);
		pipeSpawner.SetActive(false);
	}

	public void PlayGame()
	{
		SetPause(false);

		uiManager.StartGame();
		playerController.SetGravity(true);
		pipeSpawner.SetActive(true);
	}

	public void EndGame()
	{
		SetPause(true);

		uiManager.EndGame();
		playerController.SetGravity(false);
		pipeSpawner.SetActive(false);
	}

	public void SetPause(bool pause)
	{
		Time.timeScale = pause ? 0f : 1f;
	}

	public void ScoreUp()
	{
		score++;
		if (score > bestScore)
		{
			bestScore = score;
		}

		uiManager.SetScore(score);
		uiManager.SetBestScore(bestScore);
	}

}
