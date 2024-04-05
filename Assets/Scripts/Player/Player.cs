using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mob, IMoveable 
{
    #region IMoveable

    public PlayerData playerData;

    public Rigidbody2D rb;
    public Transform spriteTransform;
    public bool faceToRightAsDefault = true;
    public Animator animator;

    public MultipleSourcesNumber BaseSpeed
    {
        get => playerData.Speed;
        set => playerData.Speed = value;
    }
    public Rigidbody2D RB
    {
        get => rb;
    }
    public Transform SpriteTransform
    {
        get => spriteTransform;
    }
    public Vector2 Direction { get; set; }
    public bool FaceToRightAsDefault
    {
        get => faceToRightAsDefault;
    }
    public Func<Vector2, Vector2> VelocityPreFuncs { get; set; }
    public Func<Vector2, Vector2> VelocityPostFuncs { get; set; }

    #endregion
}
