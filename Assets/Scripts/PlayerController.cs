using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rigid;
	private Collider2D collider2d;
	private Animator anim;
	public AudioSource jumpSound;
	public AudioSource dieSound;

	[SerializeField]
	private float jumpSpeed;

	public UnityEvent OnDied;
	public UnityEvent OnScored;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody2D>();
		collider2d = GetComponent<Collider2D>();
		anim = GetComponent<Animator>();
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
		jumpSound.Play();
	}

	public void Die()
	{
		collider2d.enabled = false;
		anim.SetBool("Die", true);
		dieSound.Play();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Die();
		OnDied?.Invoke();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		OnScored?.Invoke();
	}
}
