using UnityEngine;

public class Moviment : MonoBehaviour
{
    public float Speed = 5;
    public Vector2 Direction { get; private set; } = Vector2.zero;
    private Collider2D Call;

    public void Start()
    {
        Call = GetComponent<Collider2D>();
    }

    public void Update()
    {
        Move();
        ClampPositionToScreen();
    }

    public void Move()
    {
        Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        transform.Translate(Speed * Time.deltaTime * Direction);
    }

    public void ClampPositionToScreen()
    {
        Vector3 maxPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector3 minPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        Vector3 position = transform.position;

        Vector2 extends = Call.bounds.extents;

        minPosition.x = minPosition.x + extends.x;
        minPosition.y = minPosition.y + extends.y;
        maxPosition.x = maxPosition.x - extends.x;
        maxPosition.y = maxPosition.y - extends.y;

        position.x = Mathf.Clamp(position.x, minPosition.x, maxPosition.x);
        position.y = Mathf.Clamp(position.y, minPosition.y, maxPosition.y);

        transform.position = position;
    }
}
