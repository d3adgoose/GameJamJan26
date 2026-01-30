using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TheMask/Level")]
public class LevelSO : ScriptableObject
{
    public int numCorrectResponsesToPass;
    public List<SentenceSO> sentences;
}
