using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rigid;
	private Animator ani;

	public UnityEvent OnDied;
	public UnityEvent OnScored;

	[SerializeField]
	private float jumpSpeed;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody2D>();
		ani = GetComponent<Animator>();
	}

	private void Update()
	{
		transform.right = rigid.velocity + Vector2.right * 10;
	}

	public void StartFly()
	{
		rigid.simulated = true;
	}

	public void Jump()
	{
		rigid.velocity = Vector3.up * jumpSpeed;
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
