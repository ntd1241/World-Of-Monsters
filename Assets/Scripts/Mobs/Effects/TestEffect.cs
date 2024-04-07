using UnityEngine;

public class TestEffect : Effect
{
    public int speedUpPerSec;

    public override void Update()
    {
        base.Update();

        if (Holder is not IMoveable) return;

        ((IMoveable)Holder).BaseSpeed.BaseValue += speedUpPerSec * Time.deltaTime;
    }
}
