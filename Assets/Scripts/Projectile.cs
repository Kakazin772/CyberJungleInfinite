using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    public string TargetTag;
    public int Damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(TargetTag))
        {
            return;
        }

        HealthManager health = collision.GetComponent<HealthManager>();

        if (health != null)
        {
            health.Damage(Damage);
            Destroy(gameObject);
        }
    }
}
