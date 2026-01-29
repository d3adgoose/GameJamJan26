using UnityEngine;

[CreateAssetMenu(menuName = "TheMask/Mask")]
public class MaskSO : ScriptableObject
{
    public string maskName;

    [Tooltip("Minimum value needed for this mask")]
    public int minValue;

    [Tooltip("Maximum value allowed for this mask")]
    public int maxValue;

    public Sprite maskSprite;
}
