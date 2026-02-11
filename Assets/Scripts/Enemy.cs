using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Animator animation;
    private Collider2D coll;

    private void Start()
    {
        animation = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();

        animation.SetBool("Moving", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthManager health = collision.GetComponent<HealthManager>();

            if (health != null)
            {
                health.Damage(1);

                Destroy(gameObject);
            }

        }
    }

    private void OnHealthChange(int health)
    {
        if (health == 0)
        {
            Loose();
            return;
        }
        
        animation.SetTrigger("TakeDamage");
    }

    private void Loose()
    {
        coll.enabled = false;

        animation.SetTrigger("Explode");

        Invoke(nameof(DestroySelf), 2f);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
 