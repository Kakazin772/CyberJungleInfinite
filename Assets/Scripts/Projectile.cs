using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    public string TargetTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(TargetTag))
        {
            return;
        }

        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            if (collision.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
            }
        }

        Destroy(gameObject);
    }


}
