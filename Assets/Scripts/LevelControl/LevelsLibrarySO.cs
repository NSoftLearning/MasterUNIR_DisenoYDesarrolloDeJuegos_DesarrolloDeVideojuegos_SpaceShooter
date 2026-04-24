using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "NewLevelsLibrary", 
    menuName = "ScriptableObjects/Levels/LevelsLibrary", order = 1)]
public class LevelsLibrarySO : ScriptableObject
{
    public List<LevelDataSO> levelsData;
}
