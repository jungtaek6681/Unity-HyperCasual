using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] PlayerInput input;
    [SerializeField] Animator animator;
    [SerializeField] new Collider2D collider;

    [Header("Spec")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;

    private void Update()
    {
        Rotate();
    }

    public void Ready()
    {
        input.enabled = false;
        rigidbody.simulated = false;
    }

    public void Fly()
    {
        input.enabled = true;
        rigidbody.simulated = true;
    }

    private void Rotate()
    {
        transform.right = rigidbody.velocity + Vector2.right * moveSpeed;
    }

    private void Jump()
    {
        // rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        rigidbody.velocity = Vector2.up * jumpSpeed;
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        collider.enabled = false;
        input.enabled = false;
        Manager.Scene.CurScene<GameScene>().GameOver();
    }

    private void GetScore()
    {
        Manager.Scene.CurScene<GameScene>().GetScore();
    }

    private void OnJump(InputValue value)
    {
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetScore();
    }
}
