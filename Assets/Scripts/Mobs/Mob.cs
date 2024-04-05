using SerializeReferenceEditor.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mob is a MonoBehavior object affected by effects
public class Mob : MonoBehaviour
{
    [SerializeReference]
    [SRDemo(typeof(Effect))]
    public List<Effect> effects = new List<Effect>();

    protected virtual void Awake()
    {
        foreach (var effect in effects)
        {
            effect.Mob = this;
        }
    }
    
    protected virtual void Start()
    {
        foreach (var effect in effects)
        {
            effect.Start();
        }
    }

    protected virtual void Update()
    {
        foreach (var  effect in effects)
        {
            effect.Update();
        }
    }
}
