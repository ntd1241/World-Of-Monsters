using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[CreateAssetMenu(fileName = "InCombat", menuName = "State Machine/Player/InCombat")]
public class PlayerState_InCombat : State
{
    Player player;

    public override void Initialize()
    {
        base.Initialize();

        player = machine.GetComponent<Player>();

        ((IMoveableAdvanced)player).BaseSpeed = 5f;
    }

    public override void Update()
    {
        base.Update();

        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        player.Movement = new Vector2(x, y);

        ((IMoveableAdvanced)player).IUpdate();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        ((IMoveableAdvanced)player).IFixedUpdate();
    }
}
