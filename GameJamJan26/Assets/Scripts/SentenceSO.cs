using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "TheMask/Sentence")]
public class SentenceSO : ScriptableObject
{
    public List<SymbolSO> symbols;
    public MaskType correctMask;
}