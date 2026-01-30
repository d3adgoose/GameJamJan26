using UnityEngine;

public enum SymbolCategory
{
    Value,          // +1, -1, +2, -2, +0
    NextModifier,   // invert next, duplicate next, multiply next, nullify next
    TotalModifier   // reset (×0), future-proofing
}

public enum NextSymbolEffect
{
    None,
    Invert,
    Duplicate,
    Multiply,
    Nullify
}

public enum TotalEffect
{
    None,
    Reset
}

[CreateAssetMenu(menuName = "TheMask/Symbol")]
public class SymbolSO : ScriptableObject
{
    [Header("Visual")]
    public Sprite symbolSprite;

    [Header("Category")]
    public SymbolCategory category;

    [Header("Value (Value Symbols Only)")]
    public int value;

    [Header("Next Symbol Effect")]
    public NextSymbolEffect nextEffect;

    [Header("Total Effect")]
    public TotalEffect totalEffect;


    // function for effects?
}