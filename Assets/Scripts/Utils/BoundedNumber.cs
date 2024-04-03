using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using Unity.Collections.LowLevel.Unsafe;

public class BoundedNumber
{
    private float _value;
    private float _min;
    private float _max;

    public float Value {
        get { return _value; }
        set { _value = Mathf.Clamp(value, Min, Max); }
    }
    public float Min
    {
        get { return _min; }
        set
        {
            if (value > Max) throw new ArgumentException();
            _min = value;
            _value = Mathf.Clamp(value, Min, Max);
        }
    }
    public float Max
    {
        get { return _max; }
        set
        {
            if (value < Min) throw new ArgumentException(); 
            _max = value;
            _value = Mathf.Clamp(value, Min, Max);
        }
    }

    public BoundedNumber(float value, float min, float max)
    {
        if (min > max) throw new ArgumentException();

        Min = min;
        Max = max;
        Value = value;
    }

    #region Operators

    public static implicit operator float(BoundedNumber number)
    {
        return number.Value;
    }

    public static BoundedNumber operator +(BoundedNumber number, float value)
    {
        var result = new BoundedNumber(number.Value + value, number.Min, number.Max);
        return result;
    }

    public static BoundedNumber operator -(BoundedNumber number, float value)
    {
        var result = new BoundedNumber(number.Value - value, number.Min, number.Max);
        return result;
    }

    public static BoundedNumber operator *(BoundedNumber number, float value)
    {
        var result = new BoundedNumber(number.Value * value, number.Min, number.Max);
        return result;
    }

    public static BoundedNumber operator /(BoundedNumber number, float value)
    {
        var result = new BoundedNumber(number.Value / value, number.Min, number.Max);
        return result;
    }

    public static BoundedNumber operator ++(BoundedNumber number)
    {
        number.Value++;
        return number;
    }

    public static BoundedNumber operator --(BoundedNumber number)
    {
        number.Value--;
        return number;
    }

    #endregion
}