using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct NumberSource
{
    public float? multiplicative;
    public float? additive;
    public float? replacement;

    public NumberSource(float? _multiplcative = 1, float? _additive = 0, float? _replacement=null)
    {
        multiplicative = _multiplcative;
        additive = _additive;
        replacement = _replacement;
    }
}

[Serializable]
public class MultipleSourcesNumber
{
    public Func<NumberSource> Sources { get; set; }
    public float BaseValue;
    public float Value
    {
        get
        {
            if (Sources == null) return BaseValue;

            float multiplicative = 0;
            float additive = 0;
            float? replacement = null;

            foreach (Func<NumberSource> source in  Sources.GetInvocationList())
            {
                NumberSource result = source();
                multiplicative += result.multiplicative ?? 0;
                additive += result.additive ?? 0;
                replacement = result.replacement ?? null;
            }

            return replacement ?? (multiplicative * BaseValue + additive);
        }
    }

    public MultipleSourcesNumber(float baseValue)
    {
        BaseValue = baseValue;
    }

    public MultipleSourcesNumber(float baseValue, Func<NumberSource> sources)
    {
        BaseValue = baseValue;
        Sources = sources;
    }

    public static implicit operator float(MultipleSourcesNumber number)
    {
        return number.Value;
    }
}
