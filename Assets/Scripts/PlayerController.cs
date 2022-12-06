using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rigid;
	public AudioSource audioSource;

	[SerializeField]
	private float jumpSpeed;

	public UnityEvent OnDied;
	public UnityEvent OnScored;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (Time.timeScale <= 0)
			return;

		transform.right = rigid.velocity + Vector2.right * jumpSpeed;
	}

	public void SetGravity(bool gravity)
	{
		rigid.simulated = gravity;
	}

	public void Jump()
	{
		if (Time.timeScale <= 0)
			return;

		rigid.velocity = Vector3.up * jumpSpeed;
		audioSource.Play();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		OnDied?.Invoke();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		OnScored?.Invoke();
	}
}
