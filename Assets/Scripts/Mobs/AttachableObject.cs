using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attachable object is object holding group of effects, such as Equipment, Buff/Debuff, Runes,... anything that may apply effects to Mobs
public class AttachableObject : ScriptableObject
{
    public Mob Holder { get; set; }

    [SerializeReference, SubclassSelector]
    public List<Effect> effects = new List<Effect>();
    public virtual void OnAttach() { }
    public virtual void OnDetach() { } 
}
