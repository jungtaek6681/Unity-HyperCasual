using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] new Rigidbody2D rigidbody;

    [Header("Spec")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;

    private void Update()
    {
        Rotate();
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

    private void OnJump(InputValue value)
    {
        Jump();
    }
}
