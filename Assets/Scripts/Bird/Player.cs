using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public UnityAction<int> HealthChanged;

    private void Awake()
    {
        HealthChanged?.Invoke(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);
    }

    public void ApplyHeal(int value)
    {
        _health += value;
        HealthChanged?.Invoke(_health);
    }
}
