using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[CreateAssetMenu(fileName = "InCombat", menuName = "State Machine/Player/InCombat")]
public class PlayerState_InCombat : State
{   
    Player player;
    IMoveable movement;

    public override void Initialize()
    {
        base.Initialize();

        player = machine.GetComponent<Player>();

        movement = (IMoveable)player;
    }

    public override void Update()
    {
        base.Update();

        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        movement.Direction = new Vector2(x, y);

        movement.IUpdate();

        player.animator.SetBool("isMoving", (movement.Velocity != Vector2.zero));
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        movement.IFixedUpdate();
    }
}
