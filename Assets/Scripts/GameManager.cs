using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager instance = null;

	public PlayerController playerController;
	public Animator uiAnimator;
	public GameObject pipeSpawner;
	public TextMeshProUGUI scoreUI;
	public TextMeshProUGUI resultScoreUI;
	public TextMeshProUGUI bestScoreUI;
	public float moveSpeed;

	private int bestScore = 0;
	private int score = 0;

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

	public void EndGame()
	{
		SetPause(true);
		uiAnimator.SetBool("End", true);
	}

	public void SetPause(bool pause)
	{
		Time.timeScale = pause ? 0f : 1f;
	}

	public void ScoreUp()
	{
		score++;
		scoreUI.text = score.ToString();
		resultScoreUI.text = score.ToString();

		if (score > bestScore)
		{
			bestScore = score;
		}
		bestScoreUI.text = bestScore.ToString();
	}

}
