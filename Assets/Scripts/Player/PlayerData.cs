using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerDataOS", menuName ="SO/Player/PlayerDataOS")]
public class PlayerData : ScriptableObject
{
    #region Combat Stats
    public MultipleSourcesNumber HitPoints;
    public MultipleSourcesNumber ManaPoints;
    public MultipleSourcesNumber Speed;
    public MultipleSourcesNumber Attack;
    public MultipleSourcesNumber Defense;
    #endregion
}
