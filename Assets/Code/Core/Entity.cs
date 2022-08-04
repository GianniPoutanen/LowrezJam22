using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IEntity
{
    [Header("Stats")]
    public string EntityName;
    public float MaxHealth = 5;
    public float StartingHealth = 5;
    public float Speed = 1;

    public Guid Id { get; private set; } = Guid.NewGuid();
    public float Health { get; set; }

    public Animator Animator { get; set; }

    private void Start()
    {
        Health = StartingHealth;
        Animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        // Temp
        if (IsDead())
            GameObject.Destroy(this.gameObject);
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

        if (Animator != null)
            Animator.Play(this.EntityName.ToLower() + "_dmg");

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