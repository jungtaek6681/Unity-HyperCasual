using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public PlayerController playerController;
	public GameObject pipeSpawner;
	public UIManager uiManager;

	public AudioSource scoreSound;

	private int bestScore = 0;
	private int score = 0;

	private void Start()
	{
		ReadyGame();
	}

	public void ReadyGame()
	{
		SetPause(false);
		Config.moveSpeed = 3;

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
		// SetPause(true);
		Config.moveSpeed = 0;

		uiManager.EndGame();
		playerController.SetGravity(true);
		pipeSpawner.SetActive(false);
	}

	public void SetPause(bool pause)
	{
		Time.timeScale = pause ? 0f : 1f;
	}

	public void ScoreUp()
	{
		scoreSound.Play();

		score++;
		if (score > bestScore)
		{
			bestScore = score;
		}

		uiManager.SetScore(score);
		uiManager.SetBestScore(bestScore);
	}

}
