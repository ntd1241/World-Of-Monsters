using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Effect
{
    public Mob Holder { get; set; }

    [SerializeReference]
    public List<Condition> conditions = new List<Condition>();

    public virtual void BaseEnd()
    {
        End();
        Holder.effects.Remove(this);
    }

    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void End() { }
}