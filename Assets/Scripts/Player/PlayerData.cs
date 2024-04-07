using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerDataOS", menuName ="SO/Player/PlayerDataOS")]
public class PlayerData : ScriptableObject
{
    [SerializedDictionary]
    public SerializedDictionary<CombatStat, MultipleSourcesNumber> combatStats;
}
