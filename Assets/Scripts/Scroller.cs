using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField] Transform[] children;
    [SerializeField] float offset;
    [SerializeField] float speed;

    private void Update()
    {
        foreach (Transform child in children)
        {
            child.Translate(Vector2.left * speed * Time.deltaTime);
            if (child.position.x < -offset)
            {
                child.position = new Vector2(offset, child.position.y);
            }
        }
    }
}
