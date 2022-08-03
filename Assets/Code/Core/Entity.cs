using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IEntity
{
    [Header("Stats")]
    public float MaxHealth = 5;
    public float StartingHealth = 5;
    public float Speed = 1;

    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; set; }
    public float Health { get; set; }

    private void Start()
    {
        Health = StartingHealth;
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            return true;
        }
        return false;
    }

    public bool Hit(float amount)
    {
        this.Health -= amount;
        return IsDead();
    }
}


public interface IEntity
{
    Guid Id { get; }
    float Health { get; set; }

    bool IsDead();
    bool Hit(float amount);
}