using UnityEngine;

public interface IMoveable
{
    public float BaseSpeed { get; set; }
    public Vector2 Movement { get; set; }
    public Rigidbody2D RB { get; }
    public Vector2 Velocity
    {
        get => Movement.normalized * BaseSpeed;
    }

    public float Speed //Actual speed
    {
        get => Velocity.magnitude;
    }
    public Transform SpriteTransform { get; }

    public bool FaceToRightAsDefault { get; }

    public void IUpdate()
    {
        CorrectSpriteDirection();
    }

    public void IFixedUpdate()
    {
        RB.MovePosition(RB.position + Velocity * Time.fixedDeltaTime);
    }

    private void CorrectSpriteDirection()
    {
        if (Velocity.x != 0)
        {
            int left = FaceToRightAsDefault ? -1 : 1;
            int scaleX = (Velocity.x < 0) ? left : -left;
            Vector3 scale = SpriteTransform.localScale;
            SpriteTransform.localScale = new Vector3(scaleX, scale.y, scale.z);
        }
    }
}
