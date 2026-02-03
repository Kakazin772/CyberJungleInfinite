using UnityEngine;

public class Gun : MonoBehaviour
{
    public float speed = 5, inverval = 5;
    public string TargetTag;
    public Vector2 Direction = Vector2.up;
    public Projectile ProjectilePrefab;

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnProjectile), inverval, inverval);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnProjectile));
    }

    private void SpawnProjectile()
    {
        Projectile projectile = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
        AutoMoviment projectileMoviment = projectile.GetComponent<AutoMoviment>();

        projectile.TargetTag = TargetTag;
        projectileMoviment.Direction = Direction;
        projectileMoviment.Speed = speed;
    }
}
