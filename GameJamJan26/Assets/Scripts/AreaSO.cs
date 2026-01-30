using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TheMask/Area")]
public class AreaSO : ScriptableObject
{
    public List<LevelSO> levels;
    public string levelToLoad;
}