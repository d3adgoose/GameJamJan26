using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TheMask/Sentence")]
public class SentenceSO : ScriptableObject
{
    public List<SymbolSO> symbols;
    public MaskType correctMask;
}