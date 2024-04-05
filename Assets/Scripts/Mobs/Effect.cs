using System;

[Serializable]
public abstract class Effect
{
    public Mob Mob { get; set; }

    public virtual void Start() { }
    public virtual void Update() { }
}