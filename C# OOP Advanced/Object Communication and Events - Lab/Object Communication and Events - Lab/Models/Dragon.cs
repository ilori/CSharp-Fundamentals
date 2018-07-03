﻿using System;

public class Dragon : ITarget
{
    private const string THIS_DIED_EVENT = "{0} dies";

    private readonly string id;
    private int hp;
    private int reward;
    private bool eventTriggered;
    private IHandler handler;

    public Dragon(string id, int hp, int reward, IHandler handler)
    {
        this.id = id;
        this.hp = hp;
        this.reward = reward;
        this.handler = handler;
    }

    public bool IsDead => this.hp <= 0;

    public void ReceiveDamage(int damage)
    {
        if (!this.IsDead)
        {
            this.hp -= damage;
        }

        if (this.IsDead && !eventTriggered)
        {
            Console.WriteLine(THIS_DIED_EVENT, this);
            this.eventTriggered = true;
        }
    }

    public override string ToString()
    {
        return this.id;
    }
}