using UnityEngine;

public class ScrolingBackground : MonoBehaviour
{
    public float Speed = 5;
    public SpriteRenderer Sprite;
    private float StartPositionY, EndPositionY;

    public void Start()
    {
        StartPositionY = Sprite.transform.localPosition.y;
        EndPositionY = StartPositionY - Sprite.bounds.extents.y;
    }

    private void Update()
    {
        Sprite.transform.Translate(Vector2.down * Speed * Time.deltaTime, Space.World);

        Vector3 position = Sprite.transform.localPosition;

        if (position.y < EndPositionY)
        {
            float delta = Sprite.transform.localPosition.y - EndPositionY;

            position.y = StartPositionY - delta;

            Sprite.transform.localPosition = position;
        }
    }

    private void OnValidate()
    {
        if (Sprite == null)
        {
            Sprite = GetComponentInChildren<SpriteRenderer>();
        }
    }
}
