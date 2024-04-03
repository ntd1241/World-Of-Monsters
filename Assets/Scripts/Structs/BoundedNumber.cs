using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using Unity.Collections.LowLevel.Unsafe;

public class BoundedNumber<T> where T : struct
{
    public T Min { get; set; }
    public T Max { get; set; }
    public T Value { get; set; }

    public BoundedNumber(T Value, T Min, T Max)
    {
        this.Min = Min;
        this.Max = Max;
        this.ChangeValue(Value);
    }

    public static implicit operator T(BoundedNumber<T> number)
    {
        return number.Value;
    }

    public T ChangeValue(T Value)
    {
        float min = (float)Convert.ChangeType(this.Min, typeof(T));
        float max = (float)Convert.ChangeType(this.Max, typeof(T));
        float value = (float)Convert.ChangeType(Value, typeof(T));

        float newValue = Mathf.Min(Mathf.Max(value, min), max);
        this.Value = (T)Convert.ChangeType(newValue, typeof(float));

        return this.Value;
    }

    public static BoundedNumber<T> operator --(BoundedNumber<T> number)
    {
        float value = (float)Convert.ChangeType(number.Value, typeof(T)) - 1;

        number.ChangeValue((T)Convert.ChangeType(value, typeof(float)));

        return number;
    }

    public static BoundedNumber<T> operator -(BoundedNumber<T> number, T value)
    {
        float newValue = (float)Convert.ChangeType(number.Value, typeof(T)) - (float)Convert.ChangeType(value, typeof(T));

        return new BoundedNumber<T>((T)Convert.ChangeType(newValue, typeof(float)), number.Min, number.Max);
    }

    public static BoundedNumber<T> operator ++(BoundedNumber<T> number)
    {
        float value = (float)Convert.ChangeType(number.Value, typeof(T)) + 1;

        number.ChangeValue((T)Convert.ChangeType(value, typeof(float)));

        return number;
    }

    public static BoundedNumber<T> operator +(BoundedNumber<T> number, T value)
    {
        float newValue = (float)Convert.ChangeType(number.Value, typeof(T)) + (float)Convert.ChangeType(value, typeof(T));

        return new BoundedNumber<T>((T)Convert.ChangeType(newValue, typeof(float)), number.Min, number.Max);
    }

    public static BoundedNumber<T> operator *(BoundedNumber<T> number, T value)
    {
        float newValue = (float)Convert.ChangeType(number.Value, typeof(T)) * (float)Convert.ChangeType(value, typeof(T));

        return new BoundedNumber<T>((T)Convert.ChangeType(newValue, typeof(float)), number.Min, number.Max);
    }

    public static BoundedNumber<T> operator /(BoundedNumber<T> number, T value)
    {
        float newValue = (float)Convert.ChangeType(number.Value, typeof(T)) / (float)Convert.ChangeType(value, typeof(T));

        return new BoundedNumber<T>((T)Convert.ChangeType(newValue, typeof(float)), number.Min, number.Max);
    }
}
