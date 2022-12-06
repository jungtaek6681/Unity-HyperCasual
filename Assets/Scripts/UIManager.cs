using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public Animator anim;

	public TextMeshProUGUI scoreUI;
	public TextMeshProUGUI resultScoreUI;
	public TextMeshProUGUI resultBestScoreUI;

	public GameObject readyUI;
	public GameObject playUI;
	public GameObject endUI;

	public void ReadyGame()
	{
		readyUI.SetActive(true);
		playUI.SetActive(false);
		endUI.SetActive(false);
	}

	public void StartGame()
	{
		anim.SetBool("Start", true);

		readyUI.SetActive(false);
		playUI.SetActive(true);
		endUI.SetActive(false);
	}

	public void EndGame()
	{
		anim.SetBool("End", true);

		readyUI.SetActive(false);
		playUI.SetActive(false);
		endUI.SetActive(true);
	}

	public void SetScore(int score)
	{
		scoreUI.text = score.ToString();
		resultScoreUI.text = score.ToString();
	}

	public void SetBestScore(int bestScore)
	{
		resultBestScoreUI.text = bestScore.ToString();
	}
}
