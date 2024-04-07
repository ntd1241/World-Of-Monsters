using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mob is a MonoBehavior object affected by effects, can handle attachable objects and has stats
public class Mob : MonoBehaviour
{
    [SerializedDictionary("Stat", "Value")]
    public SerializedDictionary<CombatStat, MultipleSourcesNumber> combatStats = new();

    public List<Effect> effects = new List<Effect>();

    protected virtual void Awake()
    {
        foreach (var effect in effects)
        {
            effect.Holder = this;
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
