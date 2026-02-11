using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int StartHealth = 1, MaxHealth = 1;
    public int Health { get; private set; }

    public void Start()
    {
        Health = StartHealth;
    }

    public void Damage(int damage)
    {
        Health -= damage;

        if (Health < 0)
        {
            Health = 0;
        }

        SendMessage("OnHealthChange", Health, SendMessageOptions.RequireReceiver);
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
}
