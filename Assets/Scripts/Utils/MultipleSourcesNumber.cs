using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct NumberSource
{
    public float multiplicative;
    public float additive;

    public NumberSource(float _multiplcative = 1, float _additive = 0)
    {
        multiplicative = _multiplcative;
        additive = _additive;
    }
}

[Serializable]
public class MultipleSourcesNumber
{
    public List<NumberSource> Sources = new List<NumberSource>();
    public float BaseValue;
    public float Value
    {
        get
        {
            if (Sources == null) return BaseValue;

            float multiplicative = 1;
            float additive = 0;

            foreach (var source in  Sources)
            {
                multiplicative += source.multiplicative;
                additive += source.additive;
            }

            return multiplicative * BaseValue + additive;
        }
    }

    public MultipleSourcesNumber(float baseValue)
    {
        BaseValue = baseValue;
    }

    public MultipleSourcesNumber(float baseValue, List<NumberSource> sources)
    {
        BaseValue = baseValue;
        Sources = sources;
    }

    public static implicit operator float(MultipleSourcesNumber number)
    {
        return number.Value;
    }
}
