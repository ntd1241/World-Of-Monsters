using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IMoveableAdvanced : IMoveable
{
    public Func<Vector2, Vector2> VelocityPreFuncs { get; set; }
    public Func<Vector2, Vector2> VelocityPostFuncs { get; set; }

    Vector2 IMoveable.Velocity
    {
        get
        {
            //Calculate pre-velocity
            Vector2 preVelocity = Movement.normalized * BaseSpeed;

            if (VelocityPreFuncs == null) return preVelocity;

            foreach (Func<Vector2, Vector2> func in VelocityPreFuncs.GetInvocationList())
            {
                preVelocity += func(Movement.normalized * BaseSpeed);
            }

            //Calculate post-velocity
            if (VelocityPostFuncs == null) return preVelocity;

            Vector2 postVelocity = Vector2.zero;

            foreach (Func<Vector2, Vector2> func in VelocityPostFuncs.GetInvocationList())
            {
                postVelocity += func(preVelocity);
            }

            return preVelocity + postVelocity;
        }
    }
}
