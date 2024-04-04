using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMoveableAdvanced
{
    #region IMoveable

    public float baseSpeed = 5f;
    public Rigidbody2D rb;
    public Transform spriteTransform;
    public bool faceToRightAsDefault = true;

    public float BaseSpeed
    {
        get => baseSpeed;
        set => baseSpeed = value;
    }
    public Rigidbody2D RB
    {
        get => rb;
    }
    public Transform SpriteTransform
    {
        get => spriteTransform;
    }
    public Vector2 Movement { get; set; }
    public bool FaceToRightAsDefault
    {
        get => faceToRightAsDefault;
    }
    public Func<Vector2, Vector2> VelocityPreFuncs { get; set; }
    public Func<Vector2, Vector2> VelocityPostFuncs { get; set; }

    #endregion
}
