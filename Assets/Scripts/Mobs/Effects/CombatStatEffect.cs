using AYellowpaper.SerializedCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddTypeMenu("Effects/Combat Stat Effect")]
[Serializable]
public class CombatStatEffect : Effect
{
    [SerializedDictionary("Combat Stat", "Value")]
    public SerializedDictionary<CombatStat, NumberSource> stats = new();

    public override void Start()
    {
        if (Holder == null) return;

        foreach(var stat in stats)
        {
            var numberSource = Holder.combatStats[stat.Key];
            if (numberSource != null)
            {
                numberSource.Sources.Add(stat.Value);
            }
        }
    }

    public override void End()
    {
        if (Holder == null) return;

        foreach (var stat in stats)
        {
            var numberSource = Holder.combatStats[stat.Key];
            if (numberSource != null)
            {
                numberSource.Sources.Remove(stat.Value);
            }
        }
    }

    
}