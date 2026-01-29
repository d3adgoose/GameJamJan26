using UnityEngine;

public enum SymbolEffect
{
    Add,
    Subtract,
    Multiply,
    Negate
}

[CreateAssetMenu(menuName = "TheMask/Symbol")]
public class SymbolSO : ScriptableObject
{
    public string symbolName;
    public Sprite symbolSprite;

    public SymbolEffect effect;
    public int value;
}
