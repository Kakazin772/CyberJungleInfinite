using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animator _animator;
    private Moviment _controller;
    private Collider2D _coll;
    private Gun _gun;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<Moviment>();
        _coll = GetComponent<Collider2D>();
        _gun = GetComponentInChildren<Gun>();
    }

    private void Update()
    {
        _animator.SetFloat("Direction_Horizontal", _controller.Direction.x);
        _animator.SetFloat("Direction_Vertical", _controller.Direction.y);
    }
    
    private void OnHealthChange(int health)
    {
        if (health == 0)
        {
            Loose();
            return;
        }
        
        _animator.SetTrigger("Take_Damage");
    }

    private void Invulnerabletrue()
    {
        _animator.SetBool("Blinking", true);
    }

    private void Invulnerablefalse()
    {
        _animator.SetBool("Blinking", false);
    }

    private void Loose()
    {
        _controller.enabled = false;
        _coll.enabled = false;
        _gun.enabled = false;

        _animator.SetTrigger("Explode");

        Invoke(nameof(GameOver), 2f);
    }

    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}