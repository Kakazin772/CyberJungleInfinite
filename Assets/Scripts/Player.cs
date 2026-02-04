using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _animator;
    private Moviment _controller;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<Moviment>();
    }

    private void Update()
    {
        _animator.SetFloat("Direction_Horizontal", _controller.Direction.x);
        _animator.SetFloat("Direction_Vertical", _controller.Direction.y);
    }
}