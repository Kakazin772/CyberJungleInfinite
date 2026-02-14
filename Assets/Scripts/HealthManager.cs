using System.Collections;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int StartHealth = 1, MaxHealth = 1;
    public int Health { get; private set; }
    public float InvulnerableInterval = 1;
    private bool _isInvulnerable;


    public void Start()
    {
        Health = StartHealth;
    }

    public void Damage(int damage)
    {
        if (_isInvulnerable)
        {
            return;
        }
        
        Health -= damage;

        if (Health < 0)
        {
            Health = 0;
        }

        SendMessage("OnHealthChange", Health, SendMessageOptions.RequireReceiver);

        if (InvulnerableInterval <= 0 || Health <= 0)
        {
            return;
        }

        StartCoroutine(InvulnerableCourotine());
    }

    public void Heal(int heal)
    {
        Health += heal;

        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }

        SendMessage("OnHealthChange", Health, SendMessageOptions.RequireReceiver);
    }

    private IEnumerator InvulnerableCourotine()
    {
        _isInvulnerable = true;
        SendMessage("Invulnerabletrue", SendMessageOptions.DontRequireReceiver);

        yield return new WaitForSeconds(InvulnerableInterval);

        _isInvulnerable = false;
        SendMessage("Invulnerablefalse", SendMessageOptions.DontRequireReceiver);
    }
}
