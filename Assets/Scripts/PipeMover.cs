using UnityEngine;

public class PipeMover : MonoBehaviour
{
    public float MoveSpeed { get; set; }

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
    }
}
