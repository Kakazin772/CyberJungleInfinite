using UnityEngine;

public class AutoMoviment : MonoBehaviour
{
    public float Speed = 5;
    public Vector2 Direction = Vector2.down;

    private void Update()
    {
        transform.Translate(Speed * Time.deltaTime * Direction, Space.World);
    }
}
